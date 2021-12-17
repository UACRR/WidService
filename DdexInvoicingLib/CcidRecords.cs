using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InvoicingLib
{
    public class CcidHeaderRecord : CcidRecordBase
    {
        public String record_type { get; set; }
        public string version;
        public DateTime date;
        public string sender;
        public string receiver;
        public string ccid_id;
        public string territory;
        public DateTime start_date;
        public DateTime end_date;
        public string royalty_currency;
        public string original_revenue_basis_currency;
        public decimal? conversion_rate;
        public string work_code_type;
        public string ccid_id_correction_reference;
        public string type_of_claim;
        public string commercial_model;
        public string service_description;
        public string use_type;
        public decimal? mech_perc_split;
        public decimal? perf_perc_split;
        public string aux;

        public string DateString { get { return date == null ? null : date.ToString("yyyy-MM-dd"); } }
        public string StartDateString { get { return start_date == null ? null : start_date.ToString("yyyy-MM-dd"); } }
        public string EndDateString { get { return end_date == null ? null : end_date.ToString("yyyy-MM-dd"); } }

        public string DateFormatted { get { return date == null ? null : date.ToString("yyyyMMdd"); } }
        public string StartDateFormatted { get { return start_date == null ? null : start_date.ToString("yyyyMMdd"); } }
        public string EndDateFormatted { get { return end_date == null ? null : end_date.ToString("yyyyMMdd"); } }

        public string Quarter { get { return start_date == null ? null : $"{start_date.Year}-Q{(start_date.Month + 2)/3}"; } }
        public string Month { get { return start_date == null ? null : start_date.ToString("yyyy-MM"); } }

        public void InitFromDataReader(SqlDataReader reader)
        {
            int i = 1;
            record_type = (string)FromReader(reader, i++, typeof(string));
            version = (string)FromReader(reader, i++, typeof(string));
            date = (DateTime)FromReader(reader, i++, typeof(DateTime));
            sender = (string)FromReader(reader, i++, typeof(string));
            receiver = (string)FromReader(reader, i++, typeof(string));
            ccid_id = (string)FromReader(reader, i++, typeof(string));
            territory = (string)FromReader(reader, i++, typeof(string));
            start_date = (DateTime)FromReader(reader, i++, typeof(DateTime));
            end_date = (DateTime)FromReader(reader, i++, typeof(DateTime));
            royalty_currency = (string)FromReader(reader, i++, typeof(string));
            original_revenue_basis_currency = (string)FromReader(reader, i++, typeof(string));
            conversion_rate = (decimal?)FromReader(reader, i++, typeof(decimal?));
            work_code_type = (string)FromReader(reader, i++, typeof(string));
            ccid_id_correction_reference = (string)FromReader(reader, i++, typeof(string));
            type_of_claim = (string)FromReader(reader, i++, typeof(string));
            commercial_model = (string)FromReader(reader, i++, typeof(string));
            service_description = (string)FromReader(reader, i++, typeof(string));
            use_type = (string)FromReader(reader, i++, typeof(string));
            mech_perc_split = (decimal?)FromReader(reader, i++, typeof(decimal?));
            perf_perc_split = (decimal?)FromReader(reader, i++, typeof(decimal?));
            aux = (string)FromReader(reader, i++, typeof(string));
        }

        public void ReadFromDb(SqlConnection conn, int ddexReportingPeriodId)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"select t1.* 
                                        from CcidInHeader t1 join 
                                             ccidInFile t2 on t2.fileId = t1.fileId 
                                        where t2.ddexReportingPeriodId = @ddexReportingPeriodId 
                                        order by t2.fileId desc";
                cmd.Parameters.Add(new SqlParameter("@DdexReportingPeriodId", ddexReportingPeriodId));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                        reader.Read();
                        InitFromDataReader(reader);
                }
            }
        }

        public string BuildFileName()
        {
            //return $"CCID_{version}_{sender}_{receiver}_{ccid_id}_{territory}_{use_type}_{StartDateString}--{EndDateString}_{service_description}_IN.dat";
            if(sender.Equals("Google", StringComparison.OrdinalIgnoreCase))
            {
               return $"CCID_{version}_{sender}_{receiver}_{ccid_id}_{territory}_{use_type}_{Quarter}_{service_description}_IN.dat";
            }
            else
            {
                return $"CCID_{version}_{sender}_{receiver}_{ccid_id}_{territory}_{use_type}_{Month}_{service_description}_IN.dat";
            }
        }

        public void WriteToFile(System.IO.StreamWriter file)
        {
            file.Write(record_type + "\t");
            file.Write(version + "\t");
            file.Write(DateFormatted + "\t");
            file.Write(sender + "\t");
            file.Write(receiver + "\t");
            file.Write(ccid_id + "\t");
            file.Write(territory + "\t");
            file.Write(StartDateFormatted + "\t");
            file.Write(EndDateFormatted + "\t");
            file.Write(royalty_currency + "\t");
            file.Write(original_revenue_basis_currency + "\t");
            file.Write(Formatter.ToString(conversion_rate) + "\t");
            file.Write(work_code_type + "\t");
            file.Write(ccid_id_correction_reference + "\t");
            file.Write(type_of_claim + "\t");
            file.Write(commercial_model + "\t");
            file.Write(service_description + "\t");
            file.Write(use_type + "\t");
            file.Write(Formatter.ToString(mech_perc_split) + "\t");
            file.Write(Formatter.ToString(perf_perc_split) + "\t");
            file.Write(aux);
            file.WriteLine("");
        }

        public void UploadLine(SqlConnection conn, int ccidClFileId, string[] fields)
        {
            if (fields[0].Equals("HD", StringComparison.OrdinalIgnoreCase))
            {
                BulkUploadToSql bulkUploader = new BulkUploadToSql();
                bulkUploader.TableName = "CcidClHeader";
                bulkUploader.conn = conn;

                int i = 0;

                var data = new List<object>();
                data.Add(ccidClFileId); // fileId
                data.Add(fields[i++]); // record_type
                data.Add(fields[i++]); // version
                data.Add(CreateDate(fields[i++])); // date
                data.Add(fields[i++]); // sender
                data.Add(fields[i++]); // receiver
                data.Add(fields[i++]); // ccid_id
                data.Add(fields[i++]); // territory
                data.Add(CreateDate(fields[i++])); // start_date
                data.Add(CreateDate(fields[i++])); // end_date

                data.Add(fields[i++]); // royalty_currency
                data.Add(fields[i++]); // original_revenue_basis_currency
                data.Add(Formatter.ToDecimal(fields[i++])); // conversion_rate
                data.Add(fields[i++]); // work_code_type
                data.Add(fields[i++]); // ccid_id_correcti on_reference
                data.Add(fields[i++]); // type_of_claim
                data.Add(fields[i++]); // commercial_model
                data.Add(fields[i++]); // service_description
                data.Add(fields[i++]); // use_type
                data.Add(Formatter.ToDecimal(fields[i++])); // mech_perc_split
                data.Add(Formatter.ToDecimal(fields[i++])); // perf_perc_split
                data.Add(fields[i++]); // aux

                bulkUploader.AddData(data);
                bulkUploader.Flush();
            }
            else if (fields[0].Equals("ID", StringComparison.OrdinalIgnoreCase))
            {

            }
            else if (fields[0].Equals("TR", StringComparison.OrdinalIgnoreCase))
            {

            }
        }
    }

    public class CcidTrailerRecord : CcidRecordBase
    {
        public string record_type;
        public decimal? id_records;
        public decimal? dl_records;
        public decimal? sum_amount_licensor;
        public decimal? sum_amount_copcon;
        public decimal? sum_amount_unmatched;

        public void ReadFromDataReader(SqlDataReader reader)
        {
            int i = 1;
            record_type = (string)FromReader(reader, i++, typeof(string));
            id_records = (decimal?)FromReader(reader, i++, typeof(decimal?));
            dl_records = (decimal?)FromReader(reader, i++, typeof(decimal?));
            sum_amount_licensor = (decimal?)FromReader(reader, i++, typeof(decimal?));
            sum_amount_copcon = (decimal?)FromReader(reader, i++, typeof(decimal?));
            sum_amount_unmatched = (decimal?)FromReader(reader, i++, typeof(decimal?));
        }

        public void ReadFromDb(SqlConnection conn, int ddexReportingPeriodId)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"select t1.*
                        from CcidInTrailer t1 join 
                            ccidInFile t2 on t2.fileId = t1.fileId 
                        where t2.ddexReportingPeriodId = @ddexReportingPeriodId 
                        order by t2.fileId desc";
                cmd.Parameters.Add(new SqlParameter("@ddexReportingPeriodId", ddexReportingPeriodId));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    ReadFromDataReader(reader);
                }
            }
        }
        public void WriteToFile(System.IO.StreamWriter file)
        {
            file.Write(record_type + "\t");
            file.Write(Formatter.ToString(id_records) + "\t");
            file.Write(Formatter.ToString(dl_records) + "\t");
            file.Write(Formatter.ToString(sum_amount_licensor) + "\t");
            file.Write(Formatter.ToString(sum_amount_copcon) + "\t");
            file.Write(Formatter.ToString(sum_amount_unmatched));
            file.WriteLine("");
        }
        public void UploadLine(SqlConnection conn, int ccidClFileId, string[] fields)
        {
            BulkUploadToSql bulkUploader = new BulkUploadToSql();
            bulkUploader.TableName = "CcidClTrailer";
            bulkUploader.conn = conn;

            var data = new List<object>();
            int i = 0;
            data.Add(ccidClFileId); // fileId
            data.Add(fields[i++]); // record_type
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); // id_records
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); // dl_records
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); // sum_amount_licensor
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); // sum_amount_copcon
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); // sum_amount_unmatched
 
            bulkUploader.AddData(data);
            bulkUploader.Flush();
        }
    }

    public class CcidDetailRecord : CcidRecordBase
    {
        public string record_type;
        public string transaction_type;
        public decimal? ref_id;
        public decimal? correction_reference;
        public string sales_transaction_id;
        public string work_id;
        public string release_id;
        public string resource_id;
        public string isrc;
        public string iswc;
        public string workcode;
        public string work_title;
        public decimal? use_quantity;
        public string applied_tariff;
        public string royalty_type;
        public decimal? revenue_basis;
        public decimal? original_release_revenue_basis;
        public decimal? original_resource_revenue_basis;
        public decimal? royalty;
        public decimal? resource_share;
        public string restrictions;
        public decimal? claim_licensor_combined;
        public decimal? claim_copcon_combined;
        public decimal? claim_unmatched_combined;
        public decimal? claim_pd_combined;
        public decimal? claim_not_collected_combined;
        public decimal? amount_invoiced_total;
        public decimal? claim_licensor_mech;
        public decimal? claim_licensor_perf;
        public decimal? amount_licensor_mech;
        public decimal? amount_licensor_perf;
        public decimal? amount_copcon_mech;
        public decimal? amount_copcon_perf;
        public decimal? amount_pd_mech;
        public decimal? amount_pd_perf;
        public decimal? amount_not_collected_mech;
        public decimal? amount_not_collected_perf;
        public decimal? amount_unmatched_mech;
        public decimal? amount_unmatched_perf;
        public decimal? claim_copcon_mech;
        public decimal? claim_copcon_perf;
        public decimal? claim_pd_mech;
        public decimal? claim_pd_perf;
        public decimal? claim_not_collected_mech;
        public decimal? claim_not_collected_perf;
        public decimal? claim_unmatched_mech;
        public decimal? claim_unmatched_perf;

        public void ReadFromDb(SqlDataReader reader)
        {
            int i = 1;
            record_type = (string)FromReader(reader, i++, typeof(string));
            transaction_type = (string)FromReader(reader, i++, typeof(string));
            ref_id = (decimal?)FromReader(reader, i++, typeof(decimal?));
            correction_reference = (decimal?)FromReader(reader, i++, typeof(decimal?));
            sales_transaction_id = (string)FromReader(reader, i++, typeof(string));
            work_id = (string)FromReader(reader, i++, typeof(string));
            release_id = (string)FromReader(reader, i++, typeof(string));
            resource_id = (string)FromReader(reader, i++, typeof(string));
            isrc = (string)FromReader(reader, i++, typeof(string));
            iswc = (string)FromReader(reader, i++, typeof(string));
            workcode = (string)FromReader(reader, i++, typeof(string));
            work_title = (string)FromReader(reader, i++, typeof(string));
            use_quantity = (decimal?)FromReader(reader, i++, typeof(decimal?));
            applied_tariff = (string)FromReader(reader, i++, typeof(string));
            royalty_type = (string)FromReader(reader, i++, typeof(string));
            revenue_basis = (decimal?)FromReader(reader, i++, typeof(decimal?));
            original_release_revenue_basis = (decimal?)FromReader(reader, i++, typeof(decimal?));
            original_resource_revenue_basis = (decimal?)FromReader(reader, i++, typeof(decimal?));
            royalty = (decimal?)FromReader(reader, i++, typeof(decimal?));
            resource_share = (decimal?)FromReader(reader, i++, typeof(decimal?));
            restrictions = (string)FromReader(reader, i++, typeof(string));
            claim_licensor_combined = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_copcon_combined = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_unmatched_combined = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_pd_combined = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_not_collected_combined = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_invoiced_total = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_licensor_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_licensor_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_licensor_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_licensor_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_copcon_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_copcon_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_pd_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_pd_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_not_collected_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_not_collected_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_unmatched_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            amount_unmatched_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_copcon_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_copcon_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_pd_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_pd_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_not_collected_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_not_collected_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_unmatched_mech = (decimal?)FromReader(reader, i++, typeof(decimal?));
            claim_unmatched_perf = (decimal?)FromReader(reader, i++, typeof(decimal?));
       }

        public void WriteToFile(System.IO.StreamWriter file)
        {
            file.Write(record_type + "\t");
            file.Write(transaction_type + "\t");
            file.Write(Formatter.ToString(ref_id) + "\t");
            file.Write(Formatter.ToString(correction_reference) + "\t");
            file.Write(sales_transaction_id + "\t");
            file.Write(work_id + "\t");
            file.Write(release_id + "\t");
            file.Write(resource_id + "\t");
            file.Write(isrc + "\t");
            file.Write(iswc + "\t");
            file.Write(workcode + "\t");

            if (work_title.Contains('\t'))
                work_title = work_title.Replace('\t', ' ');
            if (work_title.Contains('\r'))
                work_title = work_title.Replace('\r', ' ');
            if (work_title.Contains('\n'))
                work_title = work_title.Replace('\n', ' ');
            file.Write(work_title + "\t");

            file.Write(Formatter.ToString(use_quantity) + "\t");
            file.Write(applied_tariff + "\t");
            file.Write(royalty_type + "\t");
            file.Write(Formatter.ToString(revenue_basis) + "\t");
            file.Write(Formatter.ToString(original_release_revenue_basis) + "\t");
            file.Write(Formatter.ToString(original_resource_revenue_basis) + "\t");
            file.Write(Formatter.ToString(royalty) + "\t");
            file.Write(Formatter.ToString(resource_share) + "\t");
            file.Write(restrictions + "\t");
            file.Write(Formatter.ToString(claim_licensor_combined) + "\t");
            file.Write(Formatter.ToString(claim_copcon_combined) + "\t");
            file.Write(Formatter.ToString(claim_unmatched_combined) + "\t");
            file.Write(Formatter.ToString(claim_pd_combined) + "\t");
            file.Write(Formatter.ToString(claim_not_collected_combined) + "\t");
            file.Write(Formatter.ToString(amount_invoiced_total) + "\t");
            file.Write(Formatter.ToString(claim_licensor_mech) + "\t");
            file.Write(Formatter.ToString(claim_licensor_perf) + "\t");
            file.Write(Formatter.ToString(amount_licensor_mech) + "\t");
            file.Write(Formatter.ToString(amount_licensor_perf) + "\t");
            file.Write(Formatter.ToString(amount_copcon_mech) + "\t");
            file.Write(Formatter.ToString(amount_copcon_perf) + "\t");
            file.Write(Formatter.ToString(amount_pd_mech) + "\t");
            file.Write(Formatter.ToString(amount_pd_perf) + "\t");
            file.Write(Formatter.ToString(amount_not_collected_mech) + "\t");
            file.Write(Formatter.ToString(amount_not_collected_perf) + "\t");
            file.Write(Formatter.ToString(amount_unmatched_mech) + "\t");
            file.Write(Formatter.ToString(amount_unmatched_perf) + "\t");
            file.Write(Formatter.ToString(claim_copcon_mech) + "\t");
            file.Write(Formatter.ToString(claim_copcon_perf) + "\t");
            file.Write(Formatter.ToString(claim_pd_mech) + "\t");
            file.Write(Formatter.ToString(claim_pd_perf) + "\t");
            file.Write(Formatter.ToString(claim_not_collected_mech) + "\t");
            file.Write(Formatter.ToString(claim_not_collected_perf) + "\t");
            file.Write(Formatter.ToString(claim_unmatched_mech) + "\t");
            file.Write(Formatter.ToString(claim_unmatched_perf));
            file.WriteLine("");
        }
        public void UploadLine(BulkUploadToSql bulkUploader, int ccidClFileId, string[] fields)
        {
            var data = new List<object>();
            int i = 0;
            data.Add(ccidClFileId); // fileId
            data.Add(fields[i++]); // record_type
            data.Add(fields[i++]); //transaction_type
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); // ref_id
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //correction_reference
            data.Add(fields[i++]); //sales_transaction_id
            data.Add(fields[i++]); //work_id
            data.Add(fields[i++]); //release_id
            data.Add(fields[i++]); //resource_id
            data.Add(fields[i++]); //isrc
            data.Add(fields[i++]); //iswc
            data.Add(fields[i++]); //workcode
            data.Add(fields[i++]); //work_title

            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //use_quantity
            data.Add(fields[i++]); //applied_tariff
            data.Add(fields[i++]); //royalty_type
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //revenue_basis

            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //original_release_revenue_basis
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //original_resource_revenue_basis
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //royalty
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //resource_share
            data.Add(fields[i++]); //restrictions
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_licensor_combined
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_copcon_combined
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_unmatched_combined
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_pd_combined
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_not_collected_combined
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_invoiced_total
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_licensor_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_licensor_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_licensor_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_licensor_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_copcon_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_copcon_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_pd_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_pd_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_not_collected_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_not_collected_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_unmatched_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //amount_unma tched_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_copcon_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_copcon_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_pd_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_pd_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_not_collected_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_not_collected_perf
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_unmatched_mech
            data.Add((decimal?)FromString(fields[i++], typeof(decimal?))); //claim_unmatched_perf
            bulkUploader.AddData(data);
       }
    }

    public class CcidRecordBase
    {
        public object FromReader(SqlDataReader reader, int index, Type type)
        {
            if (reader.IsDBNull(index))
                return null;
            else if (type == typeof(string))
            {
                return reader.GetString(index);
            }
            else if (type == typeof(DateTime))
            {
                return reader.GetDateTime(index);
            }
            else if (type == typeof(decimal?))
            {
                return reader.GetDecimal(index);
            }
            return null;
        }

        public object FromString(string field, Type type)
        {
            if (string.IsNullOrEmpty(field))
                return null;
            else if (type == typeof(string))
            {
                return field;
            }
            else if (type == typeof(DateTime))
            {
                return CreateDate(field);
            }
            else if (type == typeof(decimal?))
            {
                return Formatter.ToDecimal(field);
            }
            return null;
        }

        public DateTime CreateDate(string source)
        {
            return new DateTime(int.Parse(source.Substring(0, 4)), int.Parse(source.Substring(4, 2)), int.Parse(source.Substring(6, 2)));
        }
    }

}
