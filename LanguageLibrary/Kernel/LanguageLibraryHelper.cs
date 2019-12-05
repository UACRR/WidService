using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
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

        private readonly XmlDocument _xmlDocument;
        
        public LanguageLibraryHelper()
        {
            _xmlDocument = new XmlDocument();
        }

        internal List<LanguageInfo> GetLanguagesInfoList()
        {
            string fullPathApp = $@"{LanguageInfoPathApp}\{LanguageInfoFileName}";
            string fullPathInternal = $@"{LanguageInfoPathInternal}\{LanguageInfoFileName}";


            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                _xmlDocument.Load(fullPathInternal);
            else
                _xmlDocument.Load(fullPathApp);


            XmlElement root = _xmlDocument.DocumentElement;
            
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

                    if (childNode.Name == LanguageInfo.XMLMapper[nameof(langInfo.IncompletenessItemCount)])
                        langInfo.IncompletenessItemCount = string.IsNullOrEmpty(childNode.InnerText) ? 0 : int.Parse(childNode.InnerText);
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

            string nodeName = LanguageInfo.XMLMapper[nameof(languageInfo.IncompletenessItemCount)];
            XmlNode childNode = node.SelectSingleNode(nodeName);
            childNode.InnerText = languageInfo.IncompletenessItemCount.ToString();

            _xmlDocument.Save(fullPathApp);

            // server sync
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

            XmlNode incompletenessItemCount = _xmlDocument.CreateElement(LanguageInfo.XMLMapper[nameof(languageInfo.IncompletenessItemCount)]);
            incompletenessItemCount.InnerText = languageInfo.IncompletenessItemCount.ToString();
            element.AppendChild(incompletenessItemCount);

            _xmlDocument.Save(fullPathApp);

            // server sync
            if (Directory.Exists(LanguageInfoPathInternal) && File.Exists(fullPathInternal))
                _xmlDocument.Save(fullPathInternal);

            CreateLanguageTemplate(languageInfo);
        }

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

        internal LanguageObjectModel GetLanguageData(CultureInfo cultureInfo)
        {
            var language = new LanguageObjectModel();


            return language;
        }

        internal void UpdateLanguageData()
        {

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

            var content = xmlDocument.CreateElement("content");
            content.InnerText = string.Empty;
            uiItem.AppendChild(content);

            var description = xmlDocument.CreateElement("description");
            description.InnerText = string.Empty;
            uiItem.AppendChild(description);

            var originalContent = xmlDocument.CreateElement("originalContent");
            originalContent.InnerText = string.Empty;
            uiItem.AppendChild(originalContent);

            return uiItem;
        }

    }
}
