using System.Collections.Generic;

namespace ipsFormsDesign.Services.ObjectUploading
{
    public class ObjectRightDataParser
    {
        private const int NAME_ROW_INDEX = 1;
        private const int GENRE_ROW_INDEX = 2;
        private const int RIGHTHOLDER_ROLE_ROW_INDEX = 3;
        private const int RIGHTHOLDER_NAME_ROW_INDEX = 4;
        private const int RIGHTHOLDER_RATE_ROW_INDEX = 5;

        public List<ObjectRightData> Parse(List<List<string>> data)
        {
            var list = new List<ObjectRightData>();

            ObjectRightData currentObject = null;

            foreach (var rowData in data)
            {
                var objectName = rowData[NAME_ROW_INDEX];

                if (currentObject == null || currentObject.Name != objectName)
                {
                    currentObject = new ObjectRightData
                    {
                        RowNum = data.IndexOf(rowData) + 2,
                        Name = objectName,
                        Genre = rowData[GENRE_ROW_INDEX],
                    };

                    list.Add(currentObject);
                }

                var rightholder = new RightholderData();

                rightholder.RowNum = data.IndexOf(rowData) + 2;
                rightholder.Name = rowData[RIGHTHOLDER_NAME_ROW_INDEX];
                rightholder.CreativeRole = rowData[RIGHTHOLDER_ROLE_ROW_INDEX];

                if (decimal.TryParse(rowData[RIGHTHOLDER_RATE_ROW_INDEX], out decimal rate))
                {
                    rightholder.Rate = rate * 100;
                }

                currentObject.Rightholders.Add(rightholder);
            }

            return list;
        }
    }
}
