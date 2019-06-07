using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Extensions
{
    ///<remarks>
    /// Реалізує зберігання поточного обраного рядка RadGridView.
    /// Необхідно додати гріди, зберегти стан до оновлення, повернути збережений стан.
    ///</remarks>
    public class GridStateRecorder
    {
        private readonly List<RadGridView> _gridViewList;
        private readonly Dictionary<string, int> _stateDictionary;

        public GridStateRecorder()
        {
            _gridViewList = new List<RadGridView>();
            _stateDictionary = new Dictionary<string, int>();
        }

        /// <summary>
        ///  Додати RadGridView для роботи методів з ним
        /// </summary>
        /// <param name="gridView"></param>
        public void AddGrid(RadGridView gridView)
        {
            if(gridView != null)
                _gridViewList.Add(gridView);
        }

        /// <summary>
        /// Записати поточний стан Grid's
        /// </summary>
        public void RecordState()
        {
            if(_stateDictionary.Any())
                _stateDictionary.Clear();
            foreach (var view in _gridViewList)
            {
                if(view.CurrentRow is GridViewDataRowInfo row)
                    _stateDictionary.Add(view.Name, row.Index);
            }
        }

        /// <summary>
        /// Відновити записаний стан Grid's
        /// </summary>
        public void RestoreState()
        {
            foreach (var view in _gridViewList)
            {
                if (_stateDictionary.ContainsKey(view.Name))
                {
                    var currRow = _stateDictionary[view.Name];
                    view.MasterTemplate.Refresh();
                    var rowCountToIndex = view.RowCount;
                    if (rowCountToIndex > currRow && currRow >= 0 )
                    view.CurrentRow = view.Rows[_stateDictionary[view.Name]];
                    else if (view.Rows.Any())
                        view.CurrentRow = view.Rows.LastOrDefault();
                }
            }
            _stateDictionary.Clear();
        }

        /// <summary>
        /// Видалити записані стани Grid's
        /// </summary>
        public void ClearGridStates()
        {
            _stateDictionary.Clear();
        }
    }
}
