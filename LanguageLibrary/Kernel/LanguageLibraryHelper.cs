using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using IpsCommonTypes.Types;
using ipsFormsDesign.Services;
using LanguageLibrary.Model;

namespace LanguageLibrary.Kernel
{
    internal class LanguageLibraryHelper
    {
        private const string LanguageElement = "language";
        
        private const string LanguageInfoPathApp = @"Languages";
        // IF DEBUG
        private const string LanguageInfoPathInternal = @"..\..\..\LanguageLibrary\Languages";
        private const string LanguageInfoFileName = "LanguagesInfo.xml";

        private const string LanguageDataTemplate = "LanguageObjectModel";
        private const string UIContainer = "uiContainer";
        private const string UIItem = "uiItem";
        private const string Content = "content";
        private const string Description = "description";
        private const string DefaultContent = "defaultContent";

        private readonly XmlDocument _xmlDocument;
        
        public LanguageLibraryHelper()
        {
            _xmlDocument = new XmlDocument();
        }

        internal async Task<ResponseOfRequest> SyncOnServer()
        {
            var dictionary = new Dictionary<string, byte[]>();

            string langInfo = $@"{LanguageInfoPathApp}\{LanguageInfoFileName}";
            if (File.Exists(langInfo))
            {
                dictionary.Add(LanguageInfoFileName, File.ReadAllBytes(langInfo));
            }

            var langs = GetLanguagesInfoList();
            foreach (var languageInfo in langs)
            {
                string fileName = $"Language.{languageInfo.SpecificationCode}.xml";

                string fullPathApp = $@"{LanguageInfoPathApp}\{fileName}";

                if (File.Exists(fullPathApp))
                    dictionary.Add(fileName, File.ReadAllBytes(fullPathApp));
            }

            var result = await LanguagesService.GetInstance().SyncOnServer(dictionary);
            return result;
        }

        internal async Task SyncOnClient()
        {
            var result = await LanguagesService.GetInstance().SyncOnClient();

            foreach (var content in result)
            {
                string path = $@"{LanguageInfoPathApp}\{content.Key}";

                if (!Directory.Exists(LanguageInfoPathApp))
                    Directory.CreateDirectory(LanguageInfoPathApp);

                if (!File.Exists(path))
                {
                    using (var fs = File.Create(path))
                    {
                        await fs.WriteAsync(content.Value, 0, content.Value.Length);
                    }
                }
                else
                {
                    File.WriteAllBytes(path, content.Value);
                }
            }
        }

        internal List<LanguageInfo> GetLanguagesInfoList()
        {
            var xmlDocument = LoadXmlDocument(LanguageInfoFileName);
            XmlElement root = xmlDocument.DocumentElement;
            
            var list = new List<LanguageInfo>();

            if (root == null)
                return list;

            foreach (XmlNode node in root)
            {
                var langInfo = new LanguageInfo();

                if (node.Attributes?.Count > 0)
                {
                    string attributeNode = LanguageInfo.XMLMapper[nameof(langInfo.SpecificationCode)];
                    XmlNode attribute = node.SelectSingleNode($"@{attributeNode}");
                    langInfo.SpecificationCode = attribute?.Value;
                }

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == LanguageInfo.XMLMapper[nameof(langInfo.LanguageName)])
                        langInfo.LanguageName = childNode.InnerText;

                    if (childNode.Name == LanguageInfo.XMLMapper[nameof(langInfo.UkrainianName)])
                        langInfo.UkrainianName = childNode.InnerText;
                }

                list.Add(langInfo);
            }

            return list;
        }

        internal void UpdateLanguageInfo(LanguageInfo languageInfo)
        {
            string fullPathApp = $@"{LanguageInfoPathApp}\{LanguageInfoFileName}";
            string fullPathInternal = $@"{LanguageInfoPathInternal}\{LanguageInfoFileName}";

            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                _xmlDocument.Load(fullPathInternal);
            else
                _xmlDocument.Load(fullPathApp);

            // some code
            XmlNode root = _xmlDocument.DocumentElement;
            string xPath = $"language[@{LanguageInfo.XMLMapper[nameof(languageInfo.SpecificationCode)]}='{languageInfo.SpecificationCode}']";
            XmlNode node = root.SelectSingleNode(xPath);

            _xmlDocument.Save(fullPathApp);

            // TODO: server sync
            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                _xmlDocument.Save(fullPathInternal);
        }

        internal void CreateNewLanguage(LanguageInfo languageInfo)
        {
            string fullPathApp = $@"{LanguageInfoPathApp}\{LanguageInfoFileName}";
            string fullPathInternal = $@"{LanguageInfoPathInternal}\{LanguageInfoFileName}";

            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                _xmlDocument.Load(fullPathInternal);
            else
                _xmlDocument.Load(fullPathApp);

            XmlNode element = _xmlDocument.CreateElement(LanguageElement);
            XmlAttribute attribute = _xmlDocument.CreateAttribute(LanguageInfo.XMLMapper[nameof(languageInfo.SpecificationCode)]);
            attribute.Value = languageInfo.SpecificationCode;
            element.Attributes.Append(attribute);
            _xmlDocument.DocumentElement.AppendChild(element);

            XmlNode langName = _xmlDocument.CreateElement(LanguageInfo.XMLMapper[nameof(languageInfo.LanguageName)]);
            langName.InnerText = languageInfo.LanguageName;
            element.AppendChild(langName);

            XmlNode ukrName = _xmlDocument.CreateElement(LanguageInfo.XMLMapper[nameof(languageInfo.UkrainianName)]);
            ukrName.InnerText = languageInfo.UkrainianName;
            element.AppendChild(ukrName);

            _xmlDocument.Save(fullPathApp);

            // server sync
            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                _xmlDocument.Save(fullPathInternal);

            CreateLanguageTemplate(languageInfo);
            SyncDefaultContent(languageInfo);
        }

        /// <summary>
        /// Створити шаблон мовної конфігурації
        /// </summary>
        /// <param name="languageInfo"></param>
        private void CreateLanguageTemplate(LanguageInfo languageInfo)
        {
            var xmlDocument = new XmlDocument();
            var xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(xmlDeclaration);

            var root = xmlDocument.CreateElement(LanguageDataTemplate);

            XmlAttribute attribute = xmlDocument.CreateAttribute(LanguageInfo.XMLMapper[nameof(languageInfo.SpecificationCode)]);
            attribute.Value = languageInfo.SpecificationCode;
            
            root.Attributes.Append(attribute);

            // створити ui контейнери
            var type = typeof(LanguageObjectModel);
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var container = CreateContainer(xmlDocument, propertyInfo);
                root.AppendChild(container);
            }

            xmlDocument.AppendChild(root);

            string fileName = $"Language.{languageInfo.SpecificationCode}.xml";
            string pathApp = $@"{LanguageInfoPathApp}\{fileName}";
            string pathInternal = $@"{LanguageInfoPathInternal}\{fileName}";

            if (Directory.Exists(LanguageInfoPathInternal))
                xmlDocument.Save(pathInternal);

            xmlDocument.Save(pathApp);
        }

        /// <summary>
        /// Отримати мовну конфігурацію
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        internal LanguageObjectModel GetLanguage(CultureInfo cultureInfo)
        {
            var language = new LanguageObjectModel();
            
            string fileName = $"Language.{cultureInfo.Name}.xml";

            string fullPathApp = $@"{LanguageInfoPathApp}\{fileName}";
            string fullPathInternal = $@"{LanguageInfoPathInternal}\{fileName}";

            if (!File.Exists(fullPathApp) && !File.Exists(fullPathInternal))
                return null;

            if (Directory.Exists(LanguageInfoPathInternal))
                _xmlDocument.Load(fullPathInternal);
            else
                _xmlDocument.Load(fullPathApp);

            var root = _xmlDocument.DocumentElement;

            foreach (var propertyInfo in language.GetType().GetProperties())
            {
                string xPath = $@"{UIContainer}[@name='{propertyInfo.Name}']";
                var container = root.SelectSingleNode(xPath);

                if (container == null)
                    continue;

                var parentObject = propertyInfo.GetValue(language, null);

                var propertyType = propertyInfo.PropertyType;
                var propertiesTypeInfo = propertyType.GetProperties();
                foreach (var propertyTypeInfo in propertiesTypeInfo)
                {
                    string xPathUIitem = $@"{UIItem}[@name='{propertyTypeInfo.Name}']";
                    var uiItem = container.SelectSingleNode(xPathUIitem);
                    
                    var itemType = propertyTypeInfo.PropertyType;

                    var propertyObject = propertyTypeInfo.GetValue(parentObject, null);

                    var content = uiItem.SelectSingleNode(Content).InnerText;
                    var contentProperty = itemType.GetProperty("Content");
                    contentProperty.SetValue(propertyObject, content);

                    var defaultContent = uiItem.SelectSingleNode(DefaultContent).InnerText;
                    var defaultContentProperty = itemType.GetProperty("DefaultContent");
                    defaultContentProperty.SetValue(propertyObject, defaultContent);
                }
            }

            return language;
        }

        /// <summary>
        /// Отримати XML дані по обраній мові
        /// </summary>
        /// <param name="languageInfo"></param>
        /// <returns></returns>
        internal List<LanguageDataModel> GetLanguageData(LanguageInfo languageInfo)
        {
            string fileName = $"Language.{languageInfo.SpecificationCode}.xml";
            string fullPathApp = $@"{LanguageInfoPathApp}\{fileName}";
            string fullPathInternal = $@"{LanguageInfoPathInternal}\{fileName}";

            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                _xmlDocument.Load(fullPathInternal);
            else if (File.Exists(fullPathApp))
                _xmlDocument.Load(fullPathApp);
            else
                return null;

            var dataModel = new List<LanguageDataModel>();

            var root = _xmlDocument.DocumentElement;
            foreach (XmlNode rootChildNode in root.ChildNodes)
            {
                foreach (XmlNode childNode in rootChildNode.ChildNodes)
                {
                    var langdata = new LanguageDataModel
                    {
                        ContainerName = rootChildNode.Attributes[0].Value,
                        PropertyName = childNode.Attributes[0].Value,
                        Content = childNode.SelectSingleNode(Content).InnerText,
                        Description = childNode.SelectSingleNode(Description).InnerText,
                        DefaultContent = childNode.SelectSingleNode(DefaultContent).InnerText,
                        ComponentCategory = ComponentCategoryResource.GetComponentCategory(childNode.Attributes[0].Value),
                    };
                    dataModel.Add(langdata);
                }
            }

            return dataModel;
        }

        /// <summary>
        /// Оновити XML дані мови
        /// </summary>
        /// <param name="languageInfo"></param>
        /// <param name="dataModel"></param>
        internal void UpdateLanguageData(LanguageInfo languageInfo, LanguageDataModel dataModel)
        {
            string fileName = $"Language.{languageInfo.SpecificationCode}.xml";
            var xmlDocument = LoadXmlDocument(fileName);

            var root = xmlDocument.DocumentElement;

            string xPath = $@"{UIContainer}[@name='{dataModel.ContainerName}']";
            var container = root.SelectSingleNode(xPath);

            string xPathUIitem = $@"{UIItem}[@name='{dataModel.PropertyName}']";
            var uiItem = container.SelectSingleNode(xPathUIitem);


            var content = uiItem.SelectSingleNode(Content);
            content.InnerText = dataModel.Content;
            
            SaveXmlDocument(xmlDocument, fileName);
        }

        /// <summary>
        /// Синхронізація моделі об'єкта з файлом даних
        /// </summary>
        internal void SyncLanguageDataObjectModel()
        {
            var langs = GetLanguagesInfoList();
            foreach (var languageInfo in langs)
            {
                string fileName = $"Language.{languageInfo.SpecificationCode}.xml";

                string fullPathApp = $@"{LanguageInfoPathApp}\{fileName}";
                string fullPathInternal = $@"{LanguageInfoPathInternal}\{fileName}";

                if (!File.Exists(fullPathApp) && !File.Exists(fullPathInternal))
                    continue;

                if (Directory.Exists(LanguageInfoPathInternal))
                    _xmlDocument.Load(fullPathInternal);
                else
                    _xmlDocument.Load(fullPathApp);

                var root = _xmlDocument.DocumentElement;

                // ui контейнери
                var type = typeof(LanguageObjectModel);
                var properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    string xPath = $@"{UIContainer}[@name='{propertyInfo.Name}']";
                    var container = root.SelectSingleNode(xPath);
                    
                    if (container == null)
                    {
                        container = CreateContainer(_xmlDocument, propertyInfo);
                        root.AppendChild(container);
                        continue;
                    }

                    // створити iu елементи
                    var propertyType = propertyInfo.PropertyType;
                    var propertiesTypeInfo = propertyType.GetProperties();
                    foreach (var propertyTypeInfo in propertiesTypeInfo)
                    {
                        string xPathUIitem = $@"{UIItem}[@name='{propertyTypeInfo.Name}']";
                        var uiItem = container.SelectSingleNode(xPathUIitem);
                        
                        if (uiItem == null)
                            uiItem = CreateUIItem(_xmlDocument, propertyTypeInfo);

                        container.AppendChild(uiItem);
                    }
                }

                // вторинна синхронізація, видалення блоків якщо немає в об'єкті моделі
                // створити найменування наявних властивостей об'єкта моделі
                var existObjectModelNames = new Dictionary<string, string[]>();

                foreach (var propertyInfo in properties)
                {
                    var propertyType = propertyInfo.PropertyType;
                    var propertiesTypeInfo = propertyType.GetProperties();

                    string[] childNames = propertiesTypeInfo.Select(rec => rec.Name).ToArray();

                    existObjectModelNames.Add(propertyInfo.Name, childNames);
                }

                var removeContainerNodes = new List<XmlNode>();

                // покуш відсутніх у об'єкті моделі властивостей
                foreach (XmlNode rootChildNode in root.ChildNodes)
                {
                    // пошук відсутніх ui контейнерів, якшо відсутні видаляється блок
                    if (!existObjectModelNames.ContainsKey(rootChildNode.Attributes[0].Value))
                    {
                        removeContainerNodes.Add(rootChildNode);
                        continue;
                    }

                    // пошук відсутніх ui елементів у ui модулі
                    var removeItemNodes = new List<XmlNode>();

                    foreach (XmlNode childNode in rootChildNode.ChildNodes)
                    {
                        var childNodes = existObjectModelNames[rootChildNode.Attributes[0].Value];

                        if (!childNodes.Contains(childNode.Attributes[0].Value))
                            removeItemNodes.Add(childNode);
                    }

                    // видалення елемента ui
                    foreach (var removeItemNode in removeItemNodes)
                    {
                        rootChildNode.RemoveChild(removeItemNode);
                    }
                }

                // видалення блоку контейнера
                foreach (var removeNode in removeContainerNodes)
                {
                    root.RemoveChild(removeNode);
                }


                if (Directory.Exists(LanguageInfoPathInternal))
                    _xmlDocument.Save(fullPathInternal);

                _xmlDocument.Save(fullPathApp);
            }
        }

        private XmlElement CreateContainer(XmlDocument xmlDocument, PropertyInfo propertyInfo)
        {
            XmlElement container = xmlDocument.CreateElement(UIContainer);

            XmlAttribute attributeContainer = xmlDocument.CreateAttribute("name");
            attributeContainer.Value = propertyInfo.Name;

            container.Attributes.Append(attributeContainer);

            // створити iu елементи
            var propertyType = propertyInfo.PropertyType;
            var propertiesTypeInfo = propertyType.GetProperties();
            foreach (var propertyTypeInfo in propertiesTypeInfo)
            {
                var uiItem = CreateUIItem(xmlDocument, propertyTypeInfo);
                container.AppendChild(uiItem);
            }

            return container;
        }

        private XmlElement CreateUIItem(XmlDocument xmlDocument, PropertyInfo propertyInfo)
        {
            XmlElement uiItem = xmlDocument.CreateElement(UIItem);

            XmlAttribute attributeItem = xmlDocument.CreateAttribute("name");
            attributeItem.Value = propertyInfo.Name;

            uiItem.Attributes.Append(attributeItem);

            var content = xmlDocument.CreateElement(Content);
            content.InnerText = string.Empty;
            uiItem.AppendChild(content);

            var description = xmlDocument.CreateElement(Description);
            description.InnerText = string.Empty;
            uiItem.AppendChild(description);

            var originalContent = xmlDocument.CreateElement(DefaultContent);
            originalContent.InnerText = string.Empty;
            uiItem.AppendChild(originalContent);

            return uiItem;
        }

        /// <summary>
        /// Синхронізувати стандарний вміст мовних конфігурацій
        /// </summary>
        internal void SyncDefaultContent()
        {
            string settingsFileName = "LanguageSettings.xml";
            var xmlDocument = LoadXmlDocument(settingsFileName);

            var rootSettings = xmlDocument.DocumentElement;
            var defaultLangCode = rootSettings.SelectSingleNode("defaultLanguage").InnerText;
            
            // load default xml config
            string langFileName = $"Language.{defaultLangCode}.xml";
            var defaultXmlDocument = LoadXmlDocument(langFileName);

            var langlist = GetLanguagesInfoList();

            foreach (var languageInfo in langlist)
            {
                SyncDefaultContent(languageInfo, defaultXmlDocument, languageInfo.SpecificationCode == defaultLangCode);
            }
        }

        private void SyncDefaultContent(LanguageInfo languageInfo, XmlDocument defaultXmlDocument = null, bool itself = false)
        {
            if (defaultXmlDocument == null)
            {
                string settingsFileName = "LanguageSettings.xml";
                var xmlDoc = LoadXmlDocument(settingsFileName);

                var rootSettings = xmlDoc.DocumentElement;
                var defaultLangCode = rootSettings.SelectSingleNode("defaultLanguage").InnerText;

                string fileName = $"Language.{defaultLangCode}.xml";
                defaultXmlDocument = LoadXmlDocument(fileName);
            }

            string langFileName = $"Language.{languageInfo.SpecificationCode}.xml";
            var xmlDocument = LoadXmlDocument(langFileName);

            // оновлення стандартного контенту в основной мові
            string sourceName = itself ? Content : DefaultContent;

            foreach (XmlNode rootNodes in xmlDocument.DocumentElement.ChildNodes)
            {
                foreach (XmlNode childNodes in rootNodes.ChildNodes)
                {
                    XmlNode item = defaultXmlDocument.DocumentElement;
                    string xPath = $"{UIContainer}[@name='{rootNodes.Attributes[0].Value}']";
                    XmlNode node = item.SelectSingleNode(xPath);

                    string xPathChild = $"{UIItem}[@name='{childNodes.Attributes[0].Value}']";
                    XmlNode itemChild = node.SelectSingleNode(xPathChild);
                    
                    XmlNode sourceItem = itemChild.SelectSingleNode(sourceName);
                    childNodes.SelectSingleNode(DefaultContent).InnerText = sourceItem.InnerText;
                }
            }

            SaveXmlDocument(xmlDocument, langFileName);
        }

        private XmlDocument LoadXmlDocument(string fileName)
        {
            var xmlDocument = new XmlDocument();
            string fullPathApp = $@"{LanguageInfoPathApp}\{fileName}";
            string fullPathInternal = $@"{LanguageInfoPathInternal}\{fileName}";

            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                xmlDocument.Load(fullPathInternal);
            else
                xmlDocument.Load(fullPathApp);

            return xmlDocument;
        }

        private void SaveXmlDocument(XmlDocument xmlDocument, string fileName)
        {
            string fullPathApp = $@"{LanguageInfoPathApp}\{fileName}";
            string fullPathInternal = $@"{LanguageInfoPathInternal}\{fileName}";


            xmlDocument.Save(fullPathApp);

            // TODO: server sync
            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                xmlDocument.Save(fullPathInternal);
        }

    }
}
