using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.ClientBRList
{
    public class ClientBRListModel
    {
        /// <summary>
        /// ID клієнта
        /// </summary>
        public int CustId { get; set; }

        /// <summary>
        ///  Назва клієнта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ЄДРПОУ
        /// </summary>
        public string Innokpo { get; set; }

        /// <summary>
        /// Ід Генеральной угоди
        /// </summary>
        public int AgrId { get; set; }

        /// <summary>
        /// Номер Ген. угоди
        /// </summary>
        public string AgrNumber { get; set; }

        /// <summary>
        /// Дата ген. угоди
        /// </summary>
        public DateTime? AgrDate { get; set; }

        /// <summary>
        /// Дата початку дії
        /// </summary>
        public DateTime? DateBegin { get; set; }

        /// <summary>
        /// Кінцева дата дії
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Місто
        /// </summary>        
        public string JaCity { get; set; }

        private int? _agrStatus;
        /// <summary>
        ///  Статус Ген. Угоди
        /// </summary>
        public int? AgrStatus
        {
            get => _agrStatus;
            set
            {
                _agrStatus = value;
                if (value.HasValue)
                {
                    StatusName = IpsGlobal.AnketaDictionaties.agreementStatus.First(rec => rec.CodeI == value.Value).Name;
                }
            }
        }

        /// <summary>
        /// Назва статусу 
        /// </summary>
        public string StatusName { get; set; }

        private int? _addStatus;
        /// <summary>
        /// Статус Доп угоди
        /// </summary>
        public int? AddStatus
        {
            get => _addStatus;
            set
            {
                _addStatus = value;
                if (value.HasValue)
                {
                    AddStatusName = IpsGlobal.AnketaDictionaties.agreementStatus.First(rec =>rec.CodeI == value.Value).Name;
                }
            }
        }

        /// <summary>
        /// Назва Статус 
        /// </summary>
        public string AddStatusName { get; set; }

        public float UndistribAmount { get; set; }
        public float Borg { get; set; }
        public float UnattachAmount { get; set; }
        public float PrePayRest { get; set; }

        /// <summary>
        /// Дата останього платежу
        /// </summary>
        public DateTime? DatePayLast { get; set; }

        /// <summary>
        /// Ід Партнера
        /// </summary>
        public int? ClcustId { get; set; }

        /// <summary>
        /// Назва Партнера
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Адреса
        /// </summary>
        public string JaAddress { get; set; }

        public int CountLic1Active { get; set; }
        public int CountLic1NoActive { get; set; }
        public int CountLic1ToProlong { get; set; }
        public int CountLic2Active { get; set; }
        public int CountLic2NoActive { get; set; }
        public int CountLic3Active { get; set; }
        public int CountLic3NoActive { get; set; }

        public int StatusMasterActive { get; set; }
        public int StatusMasterNoactive { get; set; }
        public int StatusMasterProlong { get; set; }
        public int StatusUndistribute { get; set; }
        public int StatusLic1Active { get; set; }
        public int StatusLic1NoActive { get; set; }
        public int StatusLic1ToProlong { get; set; }
        public int StatusLic2Active { get; set; }
        public int StatusLic2NoActive { get; set; }
        public int StatusLic3Active { get; set; }
        public int StatusLic3NoActive { get; set; }
    }
}
