using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.Extensions
{
    public class Architector
    {
        /// <summary>
        /// Створює UserControl та додає в необхідний контрол
        /// </summary>
        /// <typeparam name="C">Тип: Control</typeparam>
        /// <typeparam name="UC">Тип: UserControl</typeparam>
        /// <param name="control">Компонент в якому буде створено переданий UserControl</param>
        /// <param name="instance">UserControl компонент який буде створено</param>
        public static void IncludeInstance<C, UC>(C control, UC userControl) where C : Control where UC : UserControl, new()
        {
            if (userControl == null)
                userControl = new UC();
            userControl.Dock = DockStyle.Fill;
            control.Controls.Clear();
            control.Controls.Add(userControl);
        }

        public static UC IncludeInstanceWhithReturn<C, UC>(C control, UC userControl) where C : Control where UC : UserControl, new()
        {
            if (userControl == null)
                userControl = new UC();
            userControl.Dock = DockStyle.Fill;
            control.Controls.Clear();
            control.Controls.Add(userControl);
            return userControl;
        }
    }
}
