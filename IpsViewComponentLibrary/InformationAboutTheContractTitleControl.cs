using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class InformationAboutTheContractTitleControl : UserControl
    {
        public InformationAboutTheContractTitleControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Номер договору
        /// </summary>
        public string NumberAgr
        {
            get => numberCtrl.TextValue;
            set => numberCtrl.TextValue = value;
        }

        /// <summary>
        /// Дата договору
        /// </summary>
        public string DateAgr
        {
            get => dateCtrl.TextValue;
            set => dateCtrl.TextValue = value;
        }

        /// <summary>
        /// Представник
        /// </summary>
        public string Agent
        {
            get => agentCtrl.TextValue;
            set => agentCtrl.TextValue = value;
        }

        /// <summary>
        /// Період звітності
        /// </summary>
        public string PeriodReportind
        {
            get => periodCtrl.TextValue;
            set => periodCtrl.TextValue = value;
        }

        /// <summary>
        /// Закріпляти, навіть якщо прострочений
        /// </summary>
        public bool IsAttach
        {
            get => checkAttach.Checked;
            set => checkAttach.Checked = value;
        }

        /// <summary>
        /// Початок дії
        /// </summary>
        public string DateBegin
        {
            get => dateBeginCtrl.TextValue;
            set => dateBeginCtrl.TextValue = value;
        }

        /// <summary>
        /// Кінець дії
        /// </summary>
        public string DateEnd
        {
            get => dateEndCtrl.TextValue;
            set => dateEndCtrl.TextValue = value;
        }

        /// <summary>
        /// Пролонгація
        /// </summary>
        public bool IsProlongation
        {
            get
            {
                switch (isProlongationCtrl.TextValue)
                {
                    case "Так":
                        return true;
                    case "Ні":
                        return false;
                }
                return false;
            }
            set
            {
                if (value)
                    isProlongationCtrl.TextValue = "Так";
                if (!value)
                    isProlongationCtrl.TextValue = "Ні";
            }
        }

        /// <summary>
        /// Відсоток відрахувань
        /// </summary>
        public string Percent
        {
            get => percentCtrl.TextValue;
            set => percentCtrl.TextValue = value;
        }

        /// <summary>
        /// Мінімальна сума
        /// </summary>
        public string MinPayment
        {
            get => minPayCtrl.TextValue;
            set => minPayCtrl.TextValue = value;
        }

        /// <summary>
        /// Стан (string)
        /// </summary>
        public string State
        {
            get => stateCtrl.TextValue;
            set => stateCtrl.TextValue = value;
        }

        /// <summary>
        /// Стан (bool)
        /// </summary>
        public bool IsState
        {
            get
            {
                switch (isPayCtrl.TextValue)
                {
                    case "Дійсний":
                        return true;
                    case "Не дійсний":
                        return false;
                }
                return false;
            }
            set
            {
                if (value)
                    isPayCtrl.TextValue = "Дійсний";
                if (!value)
                    isPayCtrl.TextValue = "Не Дійсний";
            }
        }

        /// <summary>
        /// Виконання
        /// </summary>
        public string Implementation
        {
            get => implemCtrl.TextValue;
            set => implemCtrl.TextValue = value;
        }

        /// <summary>
        /// Оплата
        /// </summary>
        public bool IsPaid
        {
            get
            {
                switch (isPayCtrl.TextValue)
                {
                    case "Сплачено":
                        return true;
                    case "Не сплачено":
                        return false;
                }
                return false;
            }
            set
            {
                if (value)
                    isPayCtrl.TextValue = "Сплачено";
                if (!value)
                    isPayCtrl.TextValue = "Не сплачено";
            }
        }

        /// <summary>
        /// Банк
        /// </summary>
        public string Bank
        {
            get => bankCtrl.TextValue;
            set => bankCtrl.TextValue = value;
        }

        /// <summary>
        /// Сума звірки
        /// </summary>
        public string Amount
        {
            get => amountCtrl.TextValue;
            set => amountCtrl.TextValue = value;
        }

        /// <summary>
        /// Розподілена сума
        /// </summary>
        public string DistributedAmount
        {
            get => distributedAmountCtrl.TextValue;
            set => distributedAmountCtrl.TextValue = value;
        }

        /// <summary>
        /// Примітка
        /// </summary>
        public string Notation
        {
            get => txtNotation.Text;
            set => txtNotation.Text = value;
        }


        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="objMain">Основний об'єкт з якого будуть витягуватись дані</param>
        /// <param name="objSecond">Додатковий об'єкт з якого будуть витягуватись дані</param>
        /// <param name="other"></param>
        public void SetData(object objMain, object objSecond = null, object other = null)
        {
            Type t = objMain.GetType();
            if (t.IsEnum || objMain.GetType().IsEnum)
                ;
        }

        /// <summary>
        /// Очищення всіх полів
        /// </summary>
        public void SetEmpty()
        {
            numberCtrl.TextValue = string.Empty;
            dateCtrl.TextValue = string.Empty;
            agentCtrl.TextValue = string.Empty;
            periodCtrl.TextValue = string.Empty;
            checkAttach.Checked = default(bool);
            dateBeginCtrl.TextValue = string.Empty;
            dateEndCtrl.TextValue = string.Empty;
            isProlongationCtrl.TextValue = string.Empty;
            percentCtrl.TextValue = string.Empty;
            minPayCtrl.TextValue = string.Empty;
            stateCtrl.TextValue = string.Empty;
            implemCtrl.TextValue = string.Empty;
            isPayCtrl.TextValue = string.Empty;
            bankCtrl.TextValue = string.Empty;
            amountCtrl.TextValue = string.Empty;
            distributedAmountCtrl.TextValue = string.Empty;
            txtNotation.Text = string.Empty;
        }

        /*  - - - НАЗВИ ПОЛІВ
         *
         *NumberAgr = "";
         *DateAgr = "";
         *Agent = "";
         *PeriodReportind = "";
         *IsAttach = true;
         *DateBegin = "";
         *DateEnd = "";
         *IsProlongation = true;
         *IsTorn = ;
         *Percent = "";
         *MinPayment = "";
         *FixedPayment = "";
         *State = "";
         *Implementation = "";
         *IsPaid = true;
         *Bank = "";
         *Amount = "";
         *DistributedAmount = "";
         *Notation = "";
         *
         */
    }
}
