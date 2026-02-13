using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class HEADRecordGoogle : DdexRecordBase
    {
        enum FieldIds
        {
            MessageVersion = 1
            , Profile
            , ProfileVersion
            , MessageId
            , MessageCreatedDateTime
            , FileNumber
            , NumberofFiles
            , UsageStartDate
            , UsageEndDate
            , SenderPartyId
            , SenderName
            , ServiceDescription
            , RecipientPartyId
            , RecipientName
            , RepresentedRepertoire
        }

        public string MessageVersion { get { return fields[(int)FieldIds.MessageVersion]; } set { fields[(int)FieldIds.MessageVersion] = value; } }
        public string Profile { get { return fields[(int)FieldIds.Profile]; } set { fields[(int)FieldIds.Profile] = value; } }
        public string ProfileVersion { get { return fields[(int)FieldIds.ProfileVersion]; } set { fields[(int)FieldIds.ProfileVersion] = value; } }
        public string MessageId { get { return fields[(int)FieldIds.MessageId]; } set { fields[(int)FieldIds.MessageId] = value; } }
        public string MessageCreatedDateTime { get { return fields[(int)FieldIds.MessageCreatedDateTime]; } set { fields[(int)FieldIds.MessageCreatedDateTime] = value; } }
        public string FileNumber { get { return fields[(int)FieldIds.FileNumber]; } set { fields[(int)FieldIds.FileNumber] = value; } }
        public string NumberofFiles { get { return fields[(int)FieldIds.NumberofFiles]; } set { fields[(int)FieldIds.NumberofFiles] = value; } }
        public string UsageStartDate { get { return fields[(int)FieldIds.UsageStartDate]; } set { fields[(int)FieldIds.UsageStartDate] = value; } }
        public string UsageEndDate { get { return fields[(int)FieldIds.UsageEndDate]; } set { fields[(int)FieldIds.UsageEndDate] = value; } }
        public string SenderPartyId { get { return fields[(int)FieldIds.SenderPartyId]; } set { fields[(int)FieldIds.SenderPartyId] = value; } }
        public string SenderName { get { return fields[(int)FieldIds.SenderName]; } set { fields[(int)FieldIds.SenderName] = value; } }
        public string ServiceDescription { get { return fields[(int)FieldIds.ServiceDescription]; } set { fields[(int)FieldIds.ServiceDescription] = value; } }
        public string RecipientPartyId { get { return fields[(int)FieldIds.RecipientPartyId]; } set { fields[(int)FieldIds.RecipientPartyId] = value; } }
        public string RecipientName { get { return fields[(int)FieldIds.RecipientName]; } set { fields[(int)FieldIds.RecipientName] = value; } }
        public string RepresentedRepertoire { get { return fields[(int)FieldIds.RepresentedRepertoire]; } set { fields[(int)FieldIds.RepresentedRepertoire] = value; } }

        public override object ConvertField(int fieldIndex) {
            switch(fieldIndex)
            {
                case 0: case 1:
                    return fields[fieldIndex];
                default:
                    return fields[fieldIndex];
            }
        }

        public override int GetFieldCount() { return 16; }
    }

    public class HEADRecordApple : DdexRecordBase
    {
        enum FieldIds
        {
            MessageVersion = 1
            , ProfileVersion
            , MessageId
            , MessageCreatedDateTime
            , NumberofFiles
            , UsageStartDate
            , UsageEndDate
            , SenderPartyId
            , SenderName
        }

        public string MessageVersion { get { return fields[(int)FieldIds.MessageVersion]; } set { fields[(int)FieldIds.MessageVersion] = value; } }
        public string ProfileVersion { get { return fields[(int)FieldIds.ProfileVersion]; } set { fields[(int)FieldIds.ProfileVersion] = value; } }
        public string MessageId { get { return fields[(int)FieldIds.MessageId]; } set { fields[(int)FieldIds.MessageId] = value; } }
        public string MessageCreatedDateTime { get { return fields[(int)FieldIds.MessageCreatedDateTime]; } set { fields[(int)FieldIds.MessageCreatedDateTime] = value; } }
        public string NumberofFiles { get { return fields[(int)FieldIds.NumberofFiles]; } set { fields[(int)FieldIds.NumberofFiles] = value; } }
        public string UsageStartDate { get { return fields[(int)FieldIds.UsageStartDate]; } set { fields[(int)FieldIds.UsageStartDate] = value; } }
        public string UsageEndDate { get { return fields[(int)FieldIds.UsageEndDate]; } set { fields[(int)FieldIds.UsageEndDate] = value; } }
        public string SenderPartyId { get { return fields[(int)FieldIds.SenderPartyId]; } set { fields[(int)FieldIds.SenderPartyId] = value; } }
        public string SenderName { get { return fields[(int)FieldIds.SenderName]; } set { fields[(int)FieldIds.SenderName] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            switch (fieldIndex)
            {
                case (int)FieldIds.MessageCreatedDateTime:
                case (int)FieldIds.UsageStartDate:
                case (int)FieldIds.UsageEndDate:
                    string[] dateParts = fields[fieldIndex].Substring(0, 10).Split('-');
                    return new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
                default:
                    return fields[fieldIndex];
            }
        }

        public override int GetFieldCount() { return 10; }
    }

    public class FOOTRecord : DdexRecordBase
    {
        enum FieldIds
        {
            NumberOfLinesInFile = 1
            , NumberOfLinesInReport
            , NumberOfSummaryRecords
            , NumberOfBlocksInFile
            , NumberOfBlocksInReport
        }

        public string NumberOfLinesInFile { get { return fields[(int)FieldIds.NumberOfLinesInFile]; } set { fields[(int)FieldIds.NumberOfLinesInFile] = value; } }
        public string NumberOfLinesInReport { get { return fields[(int)FieldIds.NumberOfLinesInReport]; } set { fields[(int)FieldIds.NumberOfLinesInReport] = value; } }
        public string NumberOfSummaryRecords { get { return fields[(int)FieldIds.NumberOfSummaryRecords]; } set { fields[(int)FieldIds.NumberOfSummaryRecords] = value; } }
        public string NumberOfBlocksInFile { get { return fields[(int)FieldIds.NumberOfBlocksInFile]; } set { fields[(int)FieldIds.NumberOfBlocksInFile] = value; } }
        public string NumberOfBlocksInReport { get { return fields[(int)FieldIds.NumberOfBlocksInReport]; } set { fields[(int)FieldIds.NumberOfBlocksInReport] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            return int.Parse(fields[fieldIndex]);
        }

        public override int GetFieldCount() { return 6; }
    }

    public class SRFORecord : DdexRecordBase
    {
        enum FieldIds
        {
              NumberOfLinesInReport = 1
            , NumberOfSummaryRecords
        }

        public string NumberOfLinesInReport { get { return fields[(int)FieldIds.NumberOfLinesInReport]; } set { fields[(int)FieldIds.NumberOfLinesInReport] = value; } }
        public string NumberOfSummaryRecords { get { return fields[(int)FieldIds.NumberOfSummaryRecords]; } set { fields[(int)FieldIds.NumberOfSummaryRecords] = value; } }
        
        public override object ConvertField(int fieldIndex)
        {
            return int.Parse(fields[fieldIndex]);
        }

        public override int GetFieldCount() { return 3; }
    }

    public class SYRecord_01 : DdexRecordBase
    {
        public enum FieldIds
        {
             SummaryRecordId = 1
            , DistributionChannel
            , DistributionChannelDPID
            , CommercialModel
            , UseType
            , Territory
            , ServiceDescription
            , Usages
            , Subscribers
            , Currency
            , NetRevenue
            , IndirectNetRevenue
        }

        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DistributionChannel { get { return fields[(int)FieldIds.DistributionChannel]; } set { fields[(int)FieldIds.DistributionChannel] = value; } }
        public string DistributionChannelDPID { get { return fields[(int)FieldIds.DistributionChannelDPID]; } set { fields[(int)FieldIds.DistributionChannelDPID] = value; } }
        public string CommercialModel { get { return fields[(int)FieldIds.CommercialModel]; } set { fields[(int)FieldIds.CommercialModel] = value; } }
        public string UseType { get { return fields[(int)FieldIds.UseType]; } set { fields[(int)FieldIds.UseType] = value; } }
        public string Territory { get { return fields[(int)FieldIds.Territory]; } set { fields[(int)FieldIds.Territory] = value; } }
        public string ServiceDescription { get { return fields[(int)FieldIds.ServiceDescription]; } set { fields[(int)FieldIds.ServiceDescription] = value; } }
        public string Usages { get { return fields[(int)FieldIds.Usages]; } set { fields[(int)FieldIds.Usages] = value; } }
        public string Subscribers { get { return fields[(int)FieldIds.Subscribers]; } set { fields[(int)FieldIds.Subscribers] = value; } }
        public string Currency{ get { return fields[(int)FieldIds.Currency]; } set { fields[(int)FieldIds.Currency] = value; } }
        public string NetRevenue { get { return fields[(int)FieldIds.NetRevenue]; } set { fields[(int)FieldIds.NetRevenue] = value; } }
        public string IndirectNetRevenue { get { return fields[(int)FieldIds.IndirectNetRevenue]; } set { fields[(int)FieldIds.IndirectNetRevenue] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.Usages:
                    case (int)FieldIds.Subscribers:
                    case (int)FieldIds.NetRevenue:
                    case (int)FieldIds.IndirectNetRevenue:
                    default:
                        return fields[fieldIndex];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int GetFieldCount() { return 12; }
    }

    public class SYRecord_01_01 : DdexRecordBase
    {
        public enum FieldIds
        {
            SummaryRecordId = 1
            , DistributionChannel
            , DistributionChannelDPID
            , CommercialModel
            , UseType
            , Territory
            , ServiceDescription
            , Usages
            , Subscribers
            , CurrencyOfReporting
            , NetRevenue
            , IndirectNetRevenue
            , CurrencyOfTransaction
            , ExchangeRate
        }

        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DistributionChannel { get { return fields[(int)FieldIds.DistributionChannel]; } set { fields[(int)FieldIds.DistributionChannel] = value; } }
        public string DistributionChannelDPID { get { return fields[(int)FieldIds.DistributionChannelDPID]; } set { fields[(int)FieldIds.DistributionChannelDPID] = value; } }
        public string CommercialModel { get { return fields[(int)FieldIds.CommercialModel]; } set { fields[(int)FieldIds.CommercialModel] = value; } }
        public string UseType { get { return fields[(int)FieldIds.UseType]; } set { fields[(int)FieldIds.UseType] = value; } }
        public string Territory { get { return fields[(int)FieldIds.Territory]; } set { fields[(int)FieldIds.Territory] = value; } }
        public string ServiceDescription { get { return fields[(int)FieldIds.ServiceDescription]; } set { fields[(int)FieldIds.ServiceDescription] = value; } }
        public string Usages { get { return fields[(int)FieldIds.Usages]; } set { fields[(int)FieldIds.Usages] = value; } }
        public string Subscribers { get { return fields[(int)FieldIds.Subscribers]; } set { fields[(int)FieldIds.Subscribers] = value; } }
        public string CurrencyOfReporting { get { return fields[(int)FieldIds.CurrencyOfReporting]; } set { fields[(int)FieldIds.CurrencyOfReporting] = value; } }
        public string NetRevenue { get { return fields[(int)FieldIds.NetRevenue]; } set { fields[(int)FieldIds.NetRevenue] = value; } }
        public string IndirectNetRevenue { get { return fields[(int)FieldIds.IndirectNetRevenue]; } set { fields[(int)FieldIds.IndirectNetRevenue] = value; } }
        public string CurrencyOfTransaction { get { return fields[(int)FieldIds.CurrencyOfTransaction]; } set { fields[(int)FieldIds.CurrencyOfTransaction] = value; } }
        public string ExchangeRate { get { return fields[(int)FieldIds.ExchangeRate]; } set { fields[(int)FieldIds.ExchangeRate] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.Usages:
                    case (int)FieldIds.Subscribers:
                    case (int)FieldIds.NetRevenue:
                    case (int)FieldIds.IndirectNetRevenue:
                    case (int)FieldIds.ExchangeRate:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : Formatter.ToDecimal(fields[fieldIndex]);
                    default:
                        return fields[fieldIndex];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int GetFieldCount() { return 14; }
    }

    public class SYRecord_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            SummaryRecordId = 1
            , DistributionChannel
            , DistributionChannelDPID
            , CommercialModel
            , UseType
            , Territory
            , ServiceDescription
            , Usages
            , Users
            , Currency
            , NetRevenue
            , RightsController
            , RightsControllerPartyId
            , AllocatedUsages
            , AmountPayable
            , AllocatedNetRevenue
        }

        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DistributionChannel { get { return fields[(int)FieldIds.DistributionChannel]; } set { fields[(int)FieldIds.DistributionChannel] = value; } }
        public string DistributionChannelDPID { get { return fields[(int)FieldIds.DistributionChannelDPID]; } set { fields[(int)FieldIds.DistributionChannelDPID] = value; } }
        public string CommercialModel { get { return fields[(int)FieldIds.CommercialModel]; } set { fields[(int)FieldIds.CommercialModel] = value; } }
        public string UseType { get { return fields[(int)FieldIds.UseType]; } set { fields[(int)FieldIds.UseType] = value; } }
        public string Territory { get { return fields[(int)FieldIds.Territory]; } set { fields[(int)FieldIds.Territory] = value; } }
        public string ServiceDescription { get { return fields[(int)FieldIds.ServiceDescription]; } set { fields[(int)FieldIds.ServiceDescription] = value; } }
        public string Usages { get { return fields[(int)FieldIds.Usages]; } set { fields[(int)FieldIds.Usages] = value; } }
        public string Users { get { return fields[(int)FieldIds.Users]; } set { fields[(int)FieldIds.Users] = value; } }
        public string Currency { get { return fields[(int)FieldIds.Currency]; } set { fields[(int)FieldIds.Currency] = value; } }
        public string NetRevenue { get { return fields[(int)FieldIds.NetRevenue]; } set { fields[(int)FieldIds.NetRevenue] = value; } }
        public string RightsController { get { return fields[(int)FieldIds.RightsController]; } set { fields[(int)FieldIds.RightsController] = value; } }
        public string RightsControllerPartyId { get { return fields[(int)FieldIds.RightsControllerPartyId]; } set { fields[(int)FieldIds.RightsControllerPartyId] = value; } }
        public string AllocatedUsages { get { return fields[(int)FieldIds.AllocatedUsages]; } set { fields[(int)FieldIds.AllocatedUsages] = value; } }
        public string AllocatedRevenue { get { return fields[(int)FieldIds.AmountPayable]; } set { fields[(int)FieldIds.AmountPayable] = value; } }
        public string AllocatedNetRevenue { get { return fields[(int)FieldIds.AllocatedNetRevenue]; } set { fields[(int)FieldIds.AllocatedNetRevenue] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.Usages:
                    case (int)FieldIds.NetRevenue:
                    case (int)FieldIds.AllocatedUsages:
                    case (int)FieldIds.AmountPayable:
                    case (int)FieldIds.AllocatedNetRevenue:
                    default:
                        return fields[fieldIndex];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int GetFieldCount() { return 17; }
    }

    public class SYRecord_02_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            SummaryRecordId = 1
            , DistributionChannel
            , DistributionChannelDPID
            , CommercialModel
            , UseType
            , Territory
            , ServiceDescription
            , Usages
            , Users
            , Currency
            , NetRevenue
            , RightsController
            , RightsControllerPartyId
            , AllocatedUsages
            , AllocatedRevenue
            , AllocatedNetRevenue
            , RightsType
            , ContentCategory
            , ExchangeRateBaseCurrency
            , ExchangeRate
            , RightsTypePercentage
       }

        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DistributionChannel { get { return fields[(int)FieldIds.DistributionChannel]; } set { fields[(int)FieldIds.DistributionChannel] = value; } }
        public string DistributionChannelDPID { get { return fields[(int)FieldIds.DistributionChannelDPID]; } set { fields[(int)FieldIds.DistributionChannelDPID] = value; } }
        public string CommercialModel { get { return fields[(int)FieldIds.CommercialModel]; } set { fields[(int)FieldIds.CommercialModel] = value; } }
        public string UseType { get { return fields[(int)FieldIds.UseType]; } set { fields[(int)FieldIds.UseType] = value; } }
        public string Territory { get { return fields[(int)FieldIds.Territory]; } set { fields[(int)FieldIds.Territory] = value; } }
        public string ServiceDescription { get { return fields[(int)FieldIds.ServiceDescription]; } set { fields[(int)FieldIds.ServiceDescription] = value; } }
        public string Usages { get { return fields[(int)FieldIds.Usages]; } set { fields[(int)FieldIds.Usages] = value; } }
        public string Users { get { return fields[(int)FieldIds.Users]; } set { fields[(int)FieldIds.Users] = value; } }
        public string Currency { get { return fields[(int)FieldIds.Currency]; } set { fields[(int)FieldIds.Currency] = value; } }
        public string NetRevenue { get { return fields[(int)FieldIds.NetRevenue]; } set { fields[(int)FieldIds.NetRevenue] = value; } }
        public string RightsController { get { return fields[(int)FieldIds.RightsController]; } set { fields[(int)FieldIds.RightsController] = value; } }
        public string RightsControllerPartyId { get { return fields[(int)FieldIds.RightsControllerPartyId]; } set { fields[(int)FieldIds.RightsControllerPartyId] = value; } }
        public string AllocatedUsages { get { return fields[(int)FieldIds.AllocatedUsages]; } set { fields[(int)FieldIds.AllocatedUsages] = value; } }
        public string AllocatedRevenue { get { return fields[(int)FieldIds.AllocatedRevenue]; } set { fields[(int)FieldIds.AllocatedRevenue] = value; } }
        public string AllocatedNetRevenue { get { return fields[(int)FieldIds.AllocatedNetRevenue]; } set { fields[(int)FieldIds.AllocatedNetRevenue] = value; } }
        public string RightsType { get { return fields[(int)FieldIds.RightsType]; } set { fields[(int)FieldIds.RightsType] = value; } }
        public string ContentCategory { get { return fields[(int)FieldIds.ContentCategory]; } set { fields[(int)FieldIds.ContentCategory] = value; } }
        public string ExchangeRateBaseCurrency { get { return fields[(int)FieldIds.ExchangeRateBaseCurrency]; } set { fields[(int)FieldIds.ExchangeRateBaseCurrency] = value; } }
        public string ExchangeRate { get { return fields[(int)FieldIds.ExchangeRate]; } set { fields[(int)FieldIds.ExchangeRate] = value; } }
        public string RightsTypePercentage { get { return fields[(int)FieldIds.RightsTypePercentage]; } set { fields[(int)FieldIds.RightsTypePercentage] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.Usages:
                    case (int)FieldIds.NetRevenue:
                    case (int)FieldIds.AllocatedUsages:
                    case (int)FieldIds.AllocatedRevenue:
                    case (int)FieldIds.AllocatedNetRevenue:
                    case (int)FieldIds.ExchangeRate:
                    case (int)FieldIds.RightsTypePercentage:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : Formatter.ToDecimal(fields[fieldIndex]);
                    default:
                        return fields[fieldIndex];
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override int GetFieldCount() { return 22; }
    }

    public class SYRecord_02_03 : SYRecord_02_02
    {
    }

    public class SYRecord_04_01 : DdexRecordBase
    {
        public enum FieldIds
        {
              SummaryRecordId = 1
            , DistributionChannel 
            , DistributionChannelDPID
            , CommercialModel
            , UseType
            , Territory
            , ServiceDescription
            , SubscriberType
            , Subscribers
            , SubPeriodStartDate
            , SubPeriodEndDate
            , UsagesInSubPeriod
            , UsagesInReportingPeriod
            , Currency
            , ExchangeRateBaseCurrency
            , ExchangeRate
            , ConsumerPaidUnitPrice
            , NetRevenue
            , MusicUsagePercentage
        }

        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DistributionChannel { get { return fields[(int)FieldIds.DistributionChannel]; } set { fields[(int)FieldIds.DistributionChannel] = value; } }
        public string DistributionChannelDPID { get { return fields[(int)FieldIds.DistributionChannelDPID]; } set { fields[(int)FieldIds.DistributionChannelDPID] = value; } }
        public string CommercialModel { get { return fields[(int)FieldIds.CommercialModel]; } set { fields[(int)FieldIds.CommercialModel] = value; } }
        public string UseType { get { return fields[(int)FieldIds.UseType]; } set { fields[(int)FieldIds.UseType] = value; } }
        public string Territory { get { return fields[(int)FieldIds.Territory]; } set { fields[(int)FieldIds.Territory] = value; } }
        public string ServiceDescription { get { return fields[(int)FieldIds.ServiceDescription]; } set { fields[(int)FieldIds.ServiceDescription] = value; } }
        public string SubscriberType { get { return fields[(int)FieldIds.SubscriberType]; } set { fields[(int)FieldIds.SubscriberType] = value; } }
        public string Subscribers { get { return fields[(int)FieldIds.Subscribers]; } set { fields[(int)FieldIds.Subscribers] = value; } }
        public string SubPeriodStartDate { get { return fields[(int)FieldIds.SubPeriodStartDate]; } set { fields[(int)FieldIds.SubPeriodStartDate] = value; } }
        public string SubPeriodEndDate { get { return fields[(int)FieldIds.SubPeriodEndDate]; } set { fields[(int)FieldIds.SubPeriodEndDate] = value; } }
        public string UsagesInSubPeriod { get { return fields[(int)FieldIds.UsagesInSubPeriod]; } set { fields[(int)FieldIds.UsagesInSubPeriod] = value; } }
        public string UsagesInReportingPeriod { get { return fields[(int)FieldIds.UsagesInReportingPeriod]; } set { fields[(int)FieldIds.UsagesInReportingPeriod] = value; } }
        public string Currency { get { return fields[(int)FieldIds.Currency]; } set { fields[(int)FieldIds.Currency] = value; } }
        public string ExchangeRateBaseCurrency { get { return fields[(int)FieldIds.ExchangeRateBaseCurrency]; } set { fields[(int)FieldIds.ExchangeRateBaseCurrency] = value; } }
        public string ExchangeRate { get { return fields[(int)FieldIds.ExchangeRate]; } set { fields[(int)FieldIds.ExchangeRate] = value; } }
        public string ConsumerPaidUnitPrice { get { return fields[(int)FieldIds.ConsumerPaidUnitPrice]; } set { fields[(int)FieldIds.ConsumerPaidUnitPrice] = value; } }
        public string NetRevenue { get { return fields[(int)FieldIds.NetRevenue]; } set { fields[(int)FieldIds.NetRevenue] = value; } }
        public string MusicUsagePercentage { get { return fields[(int)FieldIds.MusicUsagePercentage]; } set { fields[(int)FieldIds.MusicUsagePercentage] = value; } }
 
        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.UsagesInSubPeriod:
                    case (int)FieldIds.Subscribers:
                    case (int)FieldIds.UsagesInReportingPeriod:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : long.Parse(fields[fieldIndex]);

                    case (int)FieldIds.ExchangeRate:
                    case (int)FieldIds.NetRevenue:
                    case (int)FieldIds.ConsumerPaidUnitPrice:
                    case (int)FieldIds.MusicUsagePercentage:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : Formatter.ToDecimal(fields[fieldIndex]);
                    case (int)FieldIds.SubPeriodStartDate:
                    case (int)FieldIds.SubPeriodEndDate:
                        string[] dateParts = fields[fieldIndex].Split('-');
                        return new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
                    default:
                        return fields[fieldIndex];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int GetFieldCount() { return 19; }
    }

    public class SYRecord_04_02 : SYRecord_04_01
    {
        public override int GetFieldCount() { return 19; }
    }

    public class SYRecord_05_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            SummaryRecordId = 1
            , DistributionChannel
            , DistributionChannelDPID
            , CommercialModel
            , UseType
            , Territory
            , ServiceDescription
            , RightsController
            , RightsControllerPartyID
            , RightsType
            , TotalUsages
            , AllocatedUsages
            , MusicUsageRatio
            , AllocatedNetRevenue
            , AllocatedRevenue
            , RightsControllerMarketShare
            , Currency
            , ExchangeRateBaseCurrency
            , ExchangeRate
            , SubscriberType
            , SubPeriodStartDate
            , SubPeriodEndDate
            , ContentCategory
            , RightsTypePercentage
        }

        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DistributionChannel { get { return fields[(int)FieldIds.DistributionChannel]; } set { fields[(int)FieldIds.DistributionChannel] = value; } }
        public string DistributionChannelDPID { get { return fields[(int)FieldIds.DistributionChannelDPID]; } set { fields[(int)FieldIds.DistributionChannelDPID] = value; } }
        public string CommercialModel { get { return fields[(int)FieldIds.CommercialModel]; } set { fields[(int)FieldIds.CommercialModel] = value; } }
        public string UseType { get { return fields[(int)FieldIds.UseType]; } set { fields[(int)FieldIds.UseType] = value; } }
        public string Territory { get { return fields[(int)FieldIds.Territory]; } set { fields[(int)FieldIds.Territory] = value; } }
        public string ServiceDescription { get { return fields[(int)FieldIds.ServiceDescription]; } set { fields[(int)FieldIds.ServiceDescription] = value; } }
        public string RightsController { get { return fields[(int)FieldIds.RightsController]; } set { fields[(int)FieldIds.RightsController] = value; } }
        public string RightsControllerPartyID { get { return fields[(int)FieldIds.RightsControllerPartyID]; } set { fields[(int)FieldIds.RightsControllerPartyID] = value; } }
        public string RightsType { get { return fields[(int)FieldIds.RightsType]; } set { fields[(int)FieldIds.RightsType] = value; } }
        public string TotalUsages { get { return fields[(int)FieldIds.TotalUsages]; } set { fields[(int)FieldIds.TotalUsages] = value; } }
        public string AllocatedUsages { get { return fields[(int)FieldIds.AllocatedUsages]; } set { fields[(int)FieldIds.AllocatedUsages] = value; } }
        public string MusicUsageRatio { get { return fields[(int)FieldIds.MusicUsageRatio]; } set { fields[(int)FieldIds.MusicUsageRatio] = value; } }
        public string AllocatedNetRevenue { get { return fields[(int)FieldIds.AllocatedNetRevenue]; } set { fields[(int)FieldIds.AllocatedNetRevenue] = value; } }
        public string AllocatedRevenue { get { return fields[(int)FieldIds.AllocatedRevenue]; } set { fields[(int)FieldIds.AllocatedRevenue] = value; } }
        public string RightsControllerMarketShare { get { return fields[(int)FieldIds.RightsControllerMarketShare]; } set { fields[(int)FieldIds.RightsControllerMarketShare] = value; } }
        public string Currency { get { return fields[(int)FieldIds.Currency]; } set { fields[(int)FieldIds.Currency] = value; } }
        public string ExchangeRateBaseCurrency { get { return fields[(int)FieldIds.ExchangeRateBaseCurrency]; } set { fields[(int)FieldIds.ExchangeRateBaseCurrency] = value; } }
        public string ExchangeRate { get { return fields[(int)FieldIds.ExchangeRate]; } set { fields[(int)FieldIds.ExchangeRate] = value; } }
        public string SubscriberType { get { return fields[(int)FieldIds.SubscriberType]; } set { fields[(int)FieldIds.SubscriberType] = value; } }
        public string SubPeriodStartDate { get { return fields[(int)FieldIds.SubPeriodStartDate]; } set { fields[(int)FieldIds.SubPeriodStartDate] = value; } }
        public string SubPeriodEndDate { get { return fields[(int)FieldIds.SubPeriodEndDate]; } set { fields[(int)FieldIds.SubPeriodEndDate] = value; } }
        public string ContentCategory { get { return fields[(int)FieldIds.ContentCategory]; } set { fields[(int)FieldIds.ContentCategory] = value; } }
        public string RightsTypePercentage { get { return fields[(int)FieldIds.RightsTypePercentage]; } set { fields[(int)FieldIds.RightsTypePercentage] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.TotalUsages:
                    case (int)FieldIds.AllocatedUsages:
                    case (int)FieldIds.MusicUsageRatio:
                    case (int)FieldIds.AllocatedNetRevenue:
                    case (int)FieldIds.AllocatedRevenue:
                    case (int)FieldIds.RightsControllerMarketShare:
                    case (int)FieldIds.ExchangeRate:
                    case (int)FieldIds.RightsTypePercentage:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : Formatter.ToDecimal(fields[fieldIndex]);
                    case (int)FieldIds.SubPeriodStartDate:
                    case (int)FieldIds.SubPeriodEndDate:
                        string[] dateParts = fields[fieldIndex].Split('-');
                        return new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
                    default:
                        return fields[fieldIndex];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int GetFieldCount() { return 24; }
    }

    public class SYRecord_05_03 : SYRecord_05_02
    {
        public override int GetFieldCount() { return 25; }
    }

    public class RERecord_01 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , ReleaseReference
            , DspReleaseId
            , ProprietaryReleaseId
            , CatalogNumber
            , ICPN
            , DisplayArtistName
            , DisplayArtistPartyId
            , Title
            , SubTitle
            , ReleaseType
            , Label
            , PLine
            , DataProvider
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string ReleaseReference { get { return fields[(int)FieldIds.ReleaseReference]; } set { fields[(int)FieldIds.ReleaseReference] = value; } }
        public string DspReleaseId { get { return fields[(int)FieldIds.DspReleaseId]; } set { fields[(int)FieldIds.DspReleaseId] = value; } }
        public string ProprietaryReleaseId { get { return fields[(int)FieldIds.ProprietaryReleaseId]; } set { fields[(int)FieldIds.ProprietaryReleaseId] = value; } }
        public string CatalogNumber { get { return fields[(int)FieldIds.CatalogNumber]; } set { fields[(int)FieldIds.CatalogNumber] = value; } }
        public string ICPN { get { return fields[(int)FieldIds.ICPN]; } set { fields[(int)FieldIds.ICPN] = value; } }
        public string DisplayArtistName { get { return fields[(int)FieldIds.DisplayArtistName]; } set { fields[(int)FieldIds.DisplayArtistName] = value; } }
        public string DisplayArtistPartyId { get { return fields[(int)FieldIds.DisplayArtistPartyId]; } set { fields[(int)FieldIds.DisplayArtistPartyId] = value; } }
        public string Title { get { return fields[(int)FieldIds.Title]; } set { fields[(int)FieldIds.Title] = value; } }
        public string SubTitle { get { return fields[(int)FieldIds.SubTitle]; } set { fields[(int)FieldIds.SubTitle] = value; } }
        public string Label { get { return fields[(int)FieldIds.Label]; } set { fields[(int)FieldIds.Label] = value; } }
        public string PLine { get { return fields[(int)FieldIds.PLine]; } set { fields[(int)FieldIds.PLine] = value; } }
        public string DataProvider { get { return fields[(int)FieldIds.DataProvider]; } set { fields[(int)FieldIds.DataProvider] = value; } }

        public override int GetFieldCount() { return 15; }
        public override bool IsBlockRecord() { return true; }
    }

    public class ASRecord_01_01 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , ResourceReference
            , DspResourceId
            , ISRC
            , Title
            , SubTitle
            , DisplayArtistName
            , DisplayArtistPartyId
            , Duration
            , ResourceType
            , IsMasterRecording
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string ResourceReference { get { return fields[(int)FieldIds.ResourceReference]; } set { fields[(int)FieldIds.ResourceReference] = value; } }
        public string DspResourceId { get { return fields[(int)FieldIds.DspResourceId]; } set { fields[(int)FieldIds.DspResourceId] = value; } }
        public string ISRC { get { return fields[(int)FieldIds.ISRC]; } set { fields[(int)FieldIds.ISRC] = value; } }
        public string Title { get { return fields[(int)FieldIds.Title]; } set { fields[(int)FieldIds.Title] = value; } }
        public string SubTitle { get { return fields[(int)FieldIds.SubTitle]; } set { fields[(int)FieldIds.SubTitle] = value; } }
        public string DisplayArtistName { get { return fields[(int)FieldIds.DisplayArtistName]; } set { fields[(int)FieldIds.DisplayArtistName] = value; } }
        public string DisplayArtistPartyId { get { return fields[(int)FieldIds.DisplayArtistPartyId]; } set { fields[(int)FieldIds.DisplayArtistPartyId] = value; } }
        public string Duration { get { return fields[(int)FieldIds.Duration]; } set { fields[(int)FieldIds.Duration] = value; } }
        public string ResourceType { get { return fields[(int)FieldIds.ResourceType]; } set { fields[(int)FieldIds.ResourceType] = value; } }
        public string IsMasterRecording { get { return fields[(int)FieldIds.IsMasterRecording]; } set { fields[(int)FieldIds.IsMasterRecording] = value; } }

        public override int GetFieldCount() { return 12; }
        public override bool IsBlockRecord() { return true; }
    }

    public class ASRecord_01_02 : ASRecord_01_01
    {
        public override int GetFieldCount() { return 14; }
    }

    public class ASRecord_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , ResourceReference
            , DspResourceId
            , ISRC
            , Title
            , SubTitle
            , DisplayArtistName
            , DisplayArtistPartyId
            , Duration
            , ResourceType
            , ISWC
            , ComposerAuthor
            , ComposerAuthorPartyId
            , Arranger
            , ArrangerPartyId
            , MusicPublisher
            , MusicPublisherPartyId
            , WorkContributor
            , WorkContributorPartyId
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string ResourceReference { get { return fields[(int)FieldIds.ResourceReference]; } set { fields[(int)FieldIds.ResourceReference] = value; } }
        public string DspResourceId { get { return fields[(int)FieldIds.DspResourceId]; } set { fields[(int)FieldIds.DspResourceId] = value; } }
        public string ISRC { get { return fields[(int)FieldIds.ISRC]; } set { fields[(int)FieldIds.ISRC] = value; } }
        public string Title { get { return fields[(int)FieldIds.Title]; } set { fields[(int)FieldIds.Title] = value; } }
        public string SubTitle { get { return fields[(int)FieldIds.SubTitle]; } set { fields[(int)FieldIds.SubTitle] = value; } }
        public string DisplayArtistName { get { return fields[(int)FieldIds.DisplayArtistName]; } set { fields[(int)FieldIds.DisplayArtistName] = value; } }
        public string DisplayArtistPartyId { get { return fields[(int)FieldIds.DisplayArtistPartyId]; } set { fields[(int)FieldIds.DisplayArtistPartyId] = value; } }
        public string Duration { get { return fields[(int)FieldIds.Duration]; } set { fields[(int)FieldIds.Duration] = value; } }
        public string ResourceType { get { return fields[(int)FieldIds.ResourceType]; } set { fields[(int)FieldIds.ResourceType] = value; } }
        public string ISWC { get { return fields[(int)FieldIds.ISWC]; } set { fields[(int)FieldIds.ISWC] = value; } }
        public string ComposerAuthor { get { return fields[(int)FieldIds.ComposerAuthor]; } set { fields[(int)FieldIds.ComposerAuthor] = value; } }
        public string ComposerAuthorPartyId { get { return fields[(int)FieldIds.ComposerAuthorPartyId]; } set { fields[(int)FieldIds.ComposerAuthorPartyId] = value; } }
        public string Arranger { get { return fields[(int)FieldIds.Arranger]; } set { fields[(int)FieldIds.Arranger] = value; } }
        public string ArrangerPartyId { get { return fields[(int)FieldIds.ArrangerPartyId]; } set { fields[(int)FieldIds.ArrangerPartyId] = value; } }
        public string MusicPublisher { get { return fields[(int)FieldIds.MusicPublisher]; } set { fields[(int)FieldIds.MusicPublisher] = value; } }
        public string MusicPublisherPartyId { get { return fields[(int)FieldIds.MusicPublisherPartyId]; } set { fields[(int)FieldIds.MusicPublisherPartyId] = value; } }
        public string WorkContributor { get { return fields[(int)FieldIds.WorkContributor]; } set { fields[(int)FieldIds.WorkContributor] = value; } }
        public string WorkContributorPartyId { get { return fields[(int)FieldIds.WorkContributorPartyId]; } set { fields[(int)FieldIds.WorkContributorPartyId] = value; } }

        public override int GetFieldCount() { return 20; }
        public override bool IsBlockRecord() { return true; }
    }

    public class ASRecord_02_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , ResourceReference
            , DspResourceId
            , ISRC
            , Title
            , SubTitle
            , DisplayArtistName
            , DisplayArtistPartyId
            , Duration
            , ResourceType
            , ISWC
            , ComposerAuthor
            , ComposerAuthorPartyId
            , Arranger
            , ArrangerPartyId
            , MusicPublisher
            , MusicPublisherPartyId
            , WorkContributor
            , WorkContributorPartyId
            , ProprietaryWorkId
            , IsMasterRecording
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string ResourceReference { get { return fields[(int)FieldIds.ResourceReference]; } set { fields[(int)FieldIds.ResourceReference] = value; } }
        public string DspResourceId { get { return fields[(int)FieldIds.DspResourceId]; } set { fields[(int)FieldIds.DspResourceId] = value; } }
        public string ISRC { get { return fields[(int)FieldIds.ISRC]; } set { fields[(int)FieldIds.ISRC] = value; } }
        public string Title { get { return fields[(int)FieldIds.Title]; } set { fields[(int)FieldIds.Title] = value; } }
        public string SubTitle { get { return fields[(int)FieldIds.SubTitle]; } set { fields[(int)FieldIds.SubTitle] = value; } }
        public string DisplayArtistName { get { return fields[(int)FieldIds.DisplayArtistName]; } set { fields[(int)FieldIds.DisplayArtistName] = value; } }
        public string DisplayArtistPartyId { get { return fields[(int)FieldIds.DisplayArtistPartyId]; } set { fields[(int)FieldIds.DisplayArtistPartyId] = value; } }
        public string Duration { get { return fields[(int)FieldIds.Duration]; } set { fields[(int)FieldIds.Duration] = value; } }
        public string ResourceType { get { return fields[(int)FieldIds.ResourceType]; } set { fields[(int)FieldIds.ResourceType] = value; } }
        public string ISWC { get { return fields[(int)FieldIds.ISWC]; } set { fields[(int)FieldIds.ISWC] = value; } }
        public string ComposerAuthor { get { return fields[(int)FieldIds.ComposerAuthor]; } set { fields[(int)FieldIds.ComposerAuthor] = value; } }
        public string ComposerAuthorPartyId { get { return fields[(int)FieldIds.ComposerAuthorPartyId]; } set { fields[(int)FieldIds.ComposerAuthorPartyId] = value; } }
        public string Arranger { get { return fields[(int)FieldIds.Arranger]; } set { fields[(int)FieldIds.Arranger] = value; } }
        public string ArrangerPartyId { get { return fields[(int)FieldIds.ArrangerPartyId]; } set { fields[(int)FieldIds.ArrangerPartyId] = value; } }
        public string MusicPublisher { get { return fields[(int)FieldIds.MusicPublisher]; } set { fields[(int)FieldIds.MusicPublisher] = value; } }
        public string MusicPublisherPartyId { get { return fields[(int)FieldIds.MusicPublisherPartyId]; } set { fields[(int)FieldIds.MusicPublisherPartyId] = value; } }
        public string WorkContributor { get { return fields[(int)FieldIds.WorkContributor]; } set { fields[(int)FieldIds.WorkContributor] = value; } }
        public string WorkContributorPartyId { get { return fields[(int)FieldIds.WorkContributorPartyId]; } set { fields[(int)FieldIds.WorkContributorPartyId] = value; } }
        public string ProprietaryWorkId { get { return fields[(int)FieldIds.ProprietaryWorkId]; } set { fields[(int)FieldIds.ProprietaryWorkId] = value; } }
        public string IsMasterRecording { get { return fields[(int)FieldIds.IsMasterRecording]; } set { fields[(int)FieldIds.IsMasterRecording] = value; } }

        public override int GetFieldCount() { return 22; }
        public override bool IsBlockRecord() { return true; }
    }

    public class RURecord_01_01 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , SummaryRecordId
            , DspReleaseId
            , Usages
            , ContentCategory
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DspReleaseId { get { return fields[(int)FieldIds.DspReleaseId]; } set { fields[(int)FieldIds.DspReleaseId] = value; } }
        public string Usages { get { return fields[(int)FieldIds.Usages]; } set { fields[(int)FieldIds.Usages] = value; } }
        public string ContentCategory { get { return fields[(int)FieldIds.ContentCategory]; } set { fields[(int)FieldIds.ContentCategory] = value; } }

        public override int GetFieldCount() { return 6; }
        public override bool IsBlockRecord() { return true; }
    }

    public class RURecord_01_02 : RURecord_01_01
    {
        public override int GetFieldCount() { return 7; }
    }

    public class SURecord_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , SummaryRecordId
            , SalesTransactionId
            , TransactedRelease
            , TransactedResource
            , IsRoyaltyBearing
            , NumberOfStreams
            , PriceConsumerPaidExcSalesTax
            , PromotionalActivity
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string SalesTransactionId { get { return fields[(int)FieldIds.SalesTransactionId]; } set { fields[(int)FieldIds.SalesTransactionId] = value; } }
        public string TransactedRelease { get { return fields[(int)FieldIds.TransactedRelease]; } set { fields[(int)FieldIds.TransactedRelease] = value; } }
        public string TransactedResource { get { return fields[(int)FieldIds.TransactedResource]; } set { fields[(int)FieldIds.TransactedResource] = value; } }
        public string IsRoyaltyBearing { get { return fields[(int)FieldIds.IsRoyaltyBearing]; } set { fields[(int)FieldIds.IsRoyaltyBearing] = value; } }
        public string NumberOfStreams { get { return fields[(int)FieldIds.NumberOfStreams]; } set { fields[(int)FieldIds.NumberOfStreams] = value; } }
        public string PriceConsumerPaidExcSalesTax { get { return fields[(int)FieldIds.PriceConsumerPaidExcSalesTax]; } set { fields[(int)FieldIds.PriceConsumerPaidExcSalesTax] = value; } }
        public string PromotionalActivity { get { return fields[(int)FieldIds.PromotionalActivity]; } set { fields[(int)FieldIds.PromotionalActivity] = value; } }

        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.NumberOfStreams:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : int.Parse(fields[fieldIndex]);
                    case (int)FieldIds.PriceConsumerPaidExcSalesTax:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : Formatter.ToDecimal(fields[fieldIndex]);
                    default:
                        return fields[fieldIndex];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override int GetFieldCount() { return 10; }
        public override bool IsBlockRecord() { return true; }
    }

    public class SURecord_03_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , SalesTransactionId
            , SummaryRecordId
            , DspReleaseId
            , Usages
            , NetRevenue
            , ValidityPeriodStart
            , ValidityPeriodEnd
            , ContentCategory
            , IsRoyaltyBearing
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string SalesTransactionId { get { return fields[(int)FieldIds.SalesTransactionId]; } set { fields[(int)FieldIds.SalesTransactionId] = value; } }
        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string DspReleaseId { get { return fields[(int)FieldIds.DspReleaseId]; } set { fields[(int)FieldIds.DspReleaseId] = value; } }
        public string Usages { get { return fields[(int)FieldIds.Usages]; } set { fields[(int)FieldIds.Usages] = value; } }
        public string NetRevenue { get { return fields[(int)FieldIds.NetRevenue]; } set { fields[(int)FieldIds.NetRevenue] = value; } }
        public string ValidityPeriodStart { get { return fields[(int)FieldIds.ValidityPeriodStart]; } set { fields[(int)FieldIds.ValidityPeriodStart] = value; } }
        public string ValidityPeriodEnd { get { return fields[(int)FieldIds.ValidityPeriodEnd]; } set { fields[(int)FieldIds.ValidityPeriodEnd] = value; } }
        public string ContentCategory { get { return fields[(int)FieldIds.ContentCategory]; } set { fields[(int)FieldIds.ContentCategory] = value; } }
        public string IsRoyaltyBearing { get { return fields[(int)FieldIds.IsRoyaltyBearing]; } set { fields[(int)FieldIds.IsRoyaltyBearing] = value; } }

        // owned records
        public List<LIRecord_01_02> liRecords = new List<LIRecord_01_02>();

        public decimal GetNetRevenue() => (decimal)ConvertField((int)FieldIds.NetRevenue);

        public override object ConvertField(int fieldIndex)
        {
            try
            {
                switch (fieldIndex)
                {
                    case (int)FieldIds.Usages:
                    case (int)FieldIds.NetRevenue:
                        return string.IsNullOrEmpty(fields[fieldIndex].Trim()) ? 0 : Formatter.ToDecimal(fields[fieldIndex]);
                    case (int)FieldIds.ValidityPeriodStart:
                    case (int)FieldIds.ValidityPeriodEnd:
                        string[] dateParts = fields[fieldIndex].Split('-');
                        return new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
                    default:
                        return fields[fieldIndex];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override int GetFieldCount() { return 11; }
        public override bool IsBlockRecord() { return true; }
    }

    public class LIRecord_01_02 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , SummaryRecordId
            , RightsController
            , RightsControllerPartyId
            , RightsControllerWorkID
            , RightSharePercent
            , RightType
            , AllocatedNetRevenue
            , AllocatedAmount
            , AllocatedUsages
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string SummaryRecordId { get { return fields[(int)FieldIds.SummaryRecordId]; } set { fields[(int)FieldIds.SummaryRecordId] = value; } }
        public string RightsController { get { return fields[(int)FieldIds.RightsController]; } set { fields[(int)FieldIds.RightsController] = value; } }
        public string RightsControllerPartyId { get { return fields[(int)FieldIds.RightsControllerPartyId]; } set { fields[(int)FieldIds.RightsControllerPartyId] = value; } }
        public string RightsControllerWorkID { get { return fields[(int)FieldIds.RightsControllerWorkID]; } set { fields[(int)FieldIds.RightsControllerWorkID] = value; } }
        public string RightSharePercent { get { return fields[(int)FieldIds.RightSharePercent]; } set { fields[(int)FieldIds.RightSharePercent] = value; } }
        public string RightType { get { return fields[(int)FieldIds.RightType]; } set { fields[(int)FieldIds.RightType] = value; } }
        public string AllocatedNetRevenue { get { return fields[(int)FieldIds.AllocatedNetRevenue]; } set { fields[(int)FieldIds.AllocatedNetRevenue] = value; } }
        public string AllocatedAmount { get { return fields[(int)FieldIds.AllocatedAmount]; } set { fields[(int)FieldIds.AllocatedAmount] = value; } }
        public string AllocatedUsages { get { return fields[(int)FieldIds.AllocatedUsages]; } set { fields[(int)FieldIds.AllocatedUsages] = value; } }

        // owned record
        public MWRecord_01_01 mwRecord;

        public override int GetFieldCount() { return 11; }
        public override bool IsBlockRecord() { return true; }
    }

    public class LIRecord_01_03 : LIRecord_01_02
    {
        public override int GetFieldCount() { return 13; }
    }

    public class MWRecord_01_01 : DdexRecordBase
    {
        public enum FieldIds
        {
            BlockId = 1
            , DspWorkId
            , ISWC
            , Title
            , SubTitle
            , ComposerAuthor
            , ComposerAuthorPartyId
            , Arranger
            , ArrangerPartyId
            , MusicPublisher
            , MusicPublisherPartyId
            , WorkContributor
            , WorkContributorPartyId
            , DataProvider
            , ProprietaryWorkId
        }

        public string BlockId { get { return fields[(int)FieldIds.BlockId]; } set { fields[(int)FieldIds.BlockId] = value; } }
        public string DspWorkId { get { return fields[(int)FieldIds.DspWorkId]; } set { fields[(int)FieldIds.DspWorkId] = value; } }
        public string ISWC { get { return fields[(int)FieldIds.ISWC]; } set { fields[(int)FieldIds.ISWC] = value; } }
        public string Title { get { return fields[(int)FieldIds.Title]; } set { fields[(int)FieldIds.Title] = value; } }
        public string SubTitle { get { return fields[(int)FieldIds.SubTitle]; } set { fields[(int)FieldIds.SubTitle] = value; } }
        public string ComposerAuthor { get { return fields[(int)FieldIds.ComposerAuthor]; } set { fields[(int)FieldIds.ComposerAuthor] = value; } }
        public string ComposerAuthorPartyId { get { return fields[(int)FieldIds.ComposerAuthorPartyId]; } set { fields[(int)FieldIds.ComposerAuthorPartyId] = value; } }
        public string Arranger { get { return fields[(int)FieldIds.Arranger]; } set { fields[(int)FieldIds.Arranger] = value; } }
        public string ArrangerPartyId { get { return fields[(int)FieldIds.ArrangerPartyId]; } set { fields[(int)FieldIds.ArrangerPartyId] = value; } }
        public string MusicPublisher { get { return fields[(int)FieldIds.MusicPublisher]; } set { fields[(int)FieldIds.MusicPublisher] = value; } }
        public string MusicPublisherPartyId { get { return fields[(int)FieldIds.MusicPublisherPartyId]; } set { fields[(int)FieldIds.MusicPublisherPartyId] = value; } }
        public string WorkContributor { get { return fields[(int)FieldIds.WorkContributor]; } set { fields[(int)FieldIds.WorkContributor] = value; } }
        public string WorkContributorPartyId { get { return fields[(int)FieldIds.WorkContributorPartyId]; } set { fields[(int)FieldIds.WorkContributorPartyId] = value; } }
        public string DataProvider { get { return fields[(int)FieldIds.DataProvider]; } set { fields[(int)FieldIds.DataProvider] = value; } }
        public string ProprietaryWorkId { get { return fields[(int)FieldIds.ProprietaryWorkId]; } set { fields[(int)FieldIds.ProprietaryWorkId] = value; } }
        public override int GetFieldCount() { return 16; }
        public override bool IsBlockRecord() { return true; }
    }

    public class MWRecord_01_02 : MWRecord_01_01
    {
        public override int GetFieldCount() { return 19; }
    }

    public class APRecord : DdexRecordBase
    {
        public enum FieldIds
        {
            TrackDspId = 1,
            TrackISRC,
            TrackTitle,
            TrackPrimaryArtist,
            TrackDuration,
            ComposerAuthor,
            Arranger,
            Publisher,
            ContentProvider,
            ISWC,
            AlbumDspId,
            AlbumUPC,
            AlbumTitle,
            PopularityRank,
            ContentType,
            RecordLabel,
            ContentProviderTrackId,
            ContentProviderAlbumId,
            SpecialAttributes,
            ReleaseYear,
            TrackNumber,
            VolumeNumber
        }

        public string TrackDspId { get { return fields[(int)FieldIds.TrackDspId]; } set { fields[(int)FieldIds.TrackDspId] = value; } }
        public string TrackISRC { get { return fields[(int)FieldIds.TrackISRC]; } set { fields[(int)FieldIds.TrackISRC] = value; } }
        public string TrackTitle { get { return fields[(int)FieldIds.TrackTitle]; } set { fields[(int)FieldIds.TrackTitle] = value; } }
        public string TrackPrimaryArtist { get { return fields[(int)FieldIds.TrackPrimaryArtist]; } set { fields[(int)FieldIds.TrackPrimaryArtist] = value; } }
        public string TrackDuration { get { return fields[(int)FieldIds.TrackDuration]; } set { fields[(int)FieldIds.TrackDuration] = value; } }
        public string ComposerAuthor { get { return fields[(int)FieldIds.ComposerAuthor]; } set { fields[(int)FieldIds.ComposerAuthor] = value; } }
        public string Arranger { get { return fields[(int)FieldIds.Arranger]; } set { fields[(int)FieldIds.Arranger] = value; } }
        public string Publisher { get { return fields[(int)FieldIds.Publisher]; } set { fields[(int)FieldIds.Publisher] = value; } }
        public string ContentProvider { get { return fields[(int)FieldIds.ContentProvider]; } set { fields[(int)FieldIds.ContentProvider] = value; } }
        public string ISWC { get { return fields[(int)FieldIds.ISWC]; } set { fields[(int)FieldIds.ISWC] = value; } }
        public string AlbumDspId { get { return fields[(int)FieldIds.AlbumDspId]; } set { fields[(int)FieldIds.AlbumDspId] = value; } }
        public string AlbumUPC { get { return fields[(int)FieldIds.AlbumUPC]; } set { fields[(int)FieldIds.AlbumUPC] = value; } }
        public string AlbumTitle { get { return fields[(int)FieldIds.AlbumTitle]; } set { fields[(int)FieldIds.AlbumTitle] = value; } }
        public string PopularityRank { get { return fields[(int)FieldIds.PopularityRank]; } set { fields[(int)FieldIds.PopularityRank] = value; } }
        public string ContentType { get { return fields[(int)FieldIds.ContentType]; } set { fields[(int)FieldIds.ContentType] = value; } }
        public string RecordLabel { get { return fields[(int)FieldIds.RecordLabel]; } set { fields[(int)FieldIds.RecordLabel] = value; } }
        public string ContentProviderTrackId { get { return fields[(int)FieldIds.ContentProviderTrackId]; } set { fields[(int)FieldIds.ContentProviderTrackId] = value; } }
        public string ContentProviderAlbumId { get { return fields[(int)FieldIds.ContentProviderAlbumId]; } set { fields[(int)FieldIds.ContentProviderAlbumId] = value; } }
        public string SpecialAttributes { get { return fields[(int)FieldIds.SpecialAttributes]; } set { fields[(int)FieldIds.SpecialAttributes] = value; } }
        public string ReleaseYear { get { return fields[(int)FieldIds.ReleaseYear]; } set { fields[(int)FieldIds.ReleaseYear] = value; } }
        public string TrackNumber { get { return fields[(int)FieldIds.TrackNumber]; } set { fields[(int)FieldIds.TrackNumber] = value; } }
        public string VolumeNumber { get { return fields[(int)FieldIds.VolumeNumber]; } set { fields[(int)FieldIds.VolumeNumber] = value; } }

        public override int GetFieldCount() { return 23; }
    }

    public class SRRecord_03_01: DdexRecordBase
    {
        public enum FieldIds
        {
	          SummaryRecordId = 2
            , DspResourceId	
            , ISRC
            , ResourceTitle
            , ResourceSubTitle
            , ResourceDisplayArtistName
            , ResourceDisplayArtistPartyId
            , Duration
            , ResourceType
            , WorkTitle
            , DspWorkId
            , ISWC
            , ComposerAuthor
            , ComposerAuthorPartyId
            , Arranger
            , ArrangerPartyId
            , MusicPublisher
            , MusicPublisherPartyId
            , WorkContributor
            , WorkContributorPartyId
            , DspReleaseId
            , ProprietaryReleaseId
            , CatalogNumber
            , ICPN
            , ReleaseDisplayArtistName
            , ReleaseDisplayArtistPartyId
            , ReleaseTitle
            , ReleaseSubTitle
            , ReleaseLabel
            , PLine
            , SalesTransactionId
            , Usages
            , NetRevenue
            , ValidityPeriodStart
            , ValidityPeriodEnd
            , ContentCategory
            , RightsController
            , RightsControllerPartyId
            , RightsControllerWorkId
            , RightShare
            , RightsType
            , AllocatedNetRevenue
            , AllocatedAmount
            , AllocatedUsages
            , AllocatedNetUsage
        }

	        public string SummaryRecordId              {get { return fields[(int)FieldIds.SummaryRecordId              ];} set { fields[(int)FieldIds.SummaryRecordId              ] = value; } }
            public string DspResourceId	               {get { return fields[(int)FieldIds.DspResourceId	               ];} set { fields[(int)FieldIds.DspResourceId	               ] = value; } }
            public string ISRC                         {get { return fields[(int)FieldIds.ISRC                         ];} set { fields[(int)FieldIds.ISRC                         ] = value; } }
            public string ResourceTitle                {get { return fields[(int)FieldIds.ResourceTitle                ];} set { fields[(int)FieldIds.ResourceTitle                ] = value; } }
            public string ResourceSubTitle             {get { return fields[(int)FieldIds.ResourceSubTitle             ];} set { fields[(int)FieldIds.ResourceSubTitle             ] = value; } }
            public string ResourceDisplayArtistName    {get { return fields[(int)FieldIds.ResourceDisplayArtistName    ];} set { fields[(int)FieldIds.ResourceDisplayArtistName    ] = value; } }
            public string ResourceDisplayArtistPartyId {get { return fields[(int)FieldIds.ResourceDisplayArtistPartyId ];} set { fields[(int)FieldIds.ResourceDisplayArtistPartyId ] = value; } }
            public string Duration                     {get { return fields[(int)FieldIds.Duration                     ];} set { fields[(int)FieldIds.Duration                     ] = value; } }
            public string ResourceType                 {get { return fields[(int)FieldIds.ResourceType                 ];} set { fields[(int)FieldIds.ResourceType                 ] = value; } }
            public string WorkTitle                    {get { return fields[(int)FieldIds.WorkTitle                    ];} set { fields[(int)FieldIds.WorkTitle                    ] = value; } }
            public string DspWorkId                    {get { return fields[(int)FieldIds.DspWorkId                    ];} set { fields[(int)FieldIds.DspWorkId                    ] = value; } }
            public string ISWC                         {get { return fields[(int)FieldIds.ISWC                         ];} set { fields[(int)FieldIds.ISWC                         ] = value; } }
            public string ComposerAuthor               {get { return fields[(int)FieldIds.ComposerAuthor               ];} set { fields[(int)FieldIds.ComposerAuthor               ] = value; } }
            public string ComposerAuthorPartyId        {get { return fields[(int)FieldIds.ComposerAuthorPartyId        ];} set { fields[(int)FieldIds.ComposerAuthorPartyId        ] = value; } }
            public string Arranger                     {get { return fields[(int)FieldIds.Arranger                     ];} set { fields[(int)FieldIds.Arranger                     ] = value; } }
            public string ArrangerPartyId              {get { return fields[(int)FieldIds.ArrangerPartyId              ];} set { fields[(int)FieldIds.ArrangerPartyId              ] = value; } }
            public string MusicPublisher               {get { return fields[(int)FieldIds.MusicPublisher               ];} set { fields[(int)FieldIds.MusicPublisher               ] = value; } }
            public string MusicPublisherPartyId        {get { return fields[(int)FieldIds.MusicPublisherPartyId        ];} set { fields[(int)FieldIds.MusicPublisherPartyId        ] = value; } }
            public string WorkContributor              {get { return fields[(int)FieldIds.WorkContributor              ];} set { fields[(int)FieldIds.WorkContributor              ] = value; } }
            public string WorkContributorPartyId       {get { return fields[(int)FieldIds.WorkContributorPartyId       ];} set { fields[(int)FieldIds.WorkContributorPartyId       ] = value; } }
            public string DspReleaseId                 {get { return fields[(int)FieldIds.DspReleaseId                 ];} set { fields[(int)FieldIds.DspReleaseId                 ] = value; } }
            public string ProprietaryReleaseId         {get { return fields[(int)FieldIds.ProprietaryReleaseId         ];} set { fields[(int)FieldIds.ProprietaryReleaseId         ] = value; } }
            public string CatalogNumber                {get { return fields[(int)FieldIds.CatalogNumber                ];} set { fields[(int)FieldIds.CatalogNumber                ] = value; } }
            public string ICPN                         {get { return fields[(int)FieldIds.ICPN                         ];} set { fields[(int)FieldIds.ICPN                         ] = value; } }
            public string ReleaseDisplayArtistName     {get { return fields[(int)FieldIds.ReleaseDisplayArtistName     ];} set { fields[(int)FieldIds.ReleaseDisplayArtistName     ] = value; } }
            public string ReleaseDisplayArtistPartyId  {get { return fields[(int)FieldIds.ReleaseDisplayArtistPartyId  ];} set { fields[(int)FieldIds.ReleaseDisplayArtistPartyId  ] = value; } }
            public string ReleaseTitle                 {get { return fields[(int)FieldIds.ReleaseTitle                 ];} set { fields[(int)FieldIds.ReleaseTitle                 ] = value; } }
            public string ReleaseSubTitle              {get { return fields[(int)FieldIds.ReleaseSubTitle              ];} set { fields[(int)FieldIds.ReleaseSubTitle              ] = value; } }
            public string ReleaseLabel                 {get { return fields[(int)FieldIds.ReleaseLabel                 ];} set { fields[(int)FieldIds.ReleaseLabel                 ] = value; } }
            public string PLine                        {get { return fields[(int)FieldIds.PLine                        ];} set { fields[(int)FieldIds.PLine                        ] = value; } }
            public string SalesTransactionId           {get { return fields[(int)FieldIds.SalesTransactionId           ];} set { fields[(int)FieldIds.SalesTransactionId           ] = value; } }
            public string Usages                       {get { return fields[(int)FieldIds.Usages                       ];} set { fields[(int)FieldIds.Usages                       ] = value; } }
            public string NetRevenue                   {get { return fields[(int)FieldIds.NetRevenue                   ];} set { fields[(int)FieldIds.NetRevenue                   ] = value; } }
            public string ValidityPeriodStart          {get { return fields[(int)FieldIds.ValidityPeriodStart          ];} set { fields[(int)FieldIds.ValidityPeriodStart          ] = value; } }
            public string ValidityPeriodEnd            {get { return fields[(int)FieldIds.ValidityPeriodEnd            ];} set { fields[(int)FieldIds.ValidityPeriodEnd            ] = value; } }
            public string ContentCategory              {get { return fields[(int)FieldIds.ContentCategory              ];} set { fields[(int)FieldIds.ContentCategory              ] = value; } }
            public string RightsController             {get { return fields[(int)FieldIds.RightsController             ];} set { fields[(int)FieldIds.RightsController             ] = value; } }
            public string RightsControllerPartyId      {get { return fields[(int)FieldIds.RightsControllerPartyId      ];} set { fields[(int)FieldIds.RightsControllerPartyId      ] = value; } }
            public string RightsControllerWorkId       {get { return fields[(int)FieldIds.RightsControllerWorkId       ];} set { fields[(int)FieldIds.RightsControllerWorkId       ] = value; } }
            public string RightShare                   {get { return fields[(int)FieldIds.RightShare                   ];} set { fields[(int)FieldIds.RightShare                   ] = value; } }
            public string RightsType                   {get { return fields[(int)FieldIds.RightsType                   ];} set { fields[(int)FieldIds.RightsType                   ] = value; } }
            public string AllocatedNetRevenue          {get { return fields[(int)FieldIds.AllocatedNetRevenue          ];} set { fields[(int)FieldIds.AllocatedNetRevenue          ] = value; } }
            public string AllocatedAmount              {get { return fields[(int)FieldIds.AllocatedAmount              ];} set { fields[(int)FieldIds.AllocatedAmount              ] = value; } }
            public string AllocatedUsages              {get { return fields[(int)FieldIds.AllocatedUsages              ];} set { fields[(int)FieldIds.AllocatedUsages              ] = value; } }
            public string AllocatedNetUsage            {get { return fields[(int)FieldIds.AllocatedNetUsage            ];} set { fields[(int)FieldIds.AllocatedNetUsage            ] = value; } }


        public override int GetFieldCount() { return 45; }
    }

    public class DdexRecordBase
    {
        public string[] fields;

        public string RecordId { get { return fields[0]; } set { fields[0] = value; } }

        public virtual object ConvertField(int fieldIndex) { return fields[fieldIndex]; }
        public virtual int GetFieldCount() { return 0; }
        public virtual bool IsBlockRecord() { return false; }

        public void Dump(string[] fields)
        {
            Logger.WriteLine("============================================");
            int i = 1;
            foreach (var field in fields)
                Logger.WriteLine("Line" + i++ + ": " + field);
            Logger.WriteLine("============================================");
        }
    }

}
