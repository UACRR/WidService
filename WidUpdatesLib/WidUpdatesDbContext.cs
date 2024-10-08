using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using WidUpdatesLib.Entities;

namespace WidUpdatesLib
{
    public class WidUpdatesDbContext : DbContext
    {
        public DbSet<DscRecType> DscRecTypes    { get; set; }
        public DbSet<DscRecField> DscRecFields  { get; set; }
        public DbSet<DscFieldColName> DscFieldColNames { get; set; }
        public DbSet<DscFmtInfo> DscFmtInfo { get; set; }

        public DbSet<UpdFile> UpdFiles { get; set; }
        public DbSet<WrkAffectedRecord> WrkAffectedRecords { get; set; }

        public DbSet<RecAck> RecAck { get; set; }
        public DbSet<RecAlt> RecAlt { get; set; }
        public DbSet<RecCom> RecCom { get; set; }
        public DbSet<RecCon> RecCon { get; set; }
        public DbSet<RecDel> RecDel { get; set; }
        public DbSet<RecEwt> RecEwt { get; set; }
        public DbSet<RecInd> RecInd { get; set; }
        public DbSet<RecIns> RecIns { get; set; }
        public DbSet<RecIsw> RecIsw { get; set; }
        public DbSet<RecLnk> RecLnk { get; set; }
        public DbSet<RecMsg> RecMsg { get; set; }
        public DbSet<RecOip> RecOip { get; set; }
        public DbSet<RecOrn> RecOrn { get; set; }
        public DbSet<RecOsr> RecOsr { get; set; }
        public DbSet<RecPer> RecPer { get; set; }
        public DbSet<RecRes> RecRes { get; set; }
        public DbSet<RecSip> RecSip { get; set; }
        public DbSet<RecSoc> RecSoc { get; set; }
        public DbSet<RecSsr> RecSsr { get; set; }
        public DbSet<RecTtu> RecTtu { get; set; }
        public DbSet<RecVer> RecVer { get; set; }
        public DbSet<RecWia> RecWia { get; set; }
        public DbSet<RecWiu> RecWiu { get; set; }
        public DbSet<RecWpl> RecWpl { get; set; }

        public WidUpdatesDbContext() : base()
        {
        }
        private string GetConnectionString()
        {
            var exeFileFullName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var rootPath = System.IO.Path.GetDirectoryName(exeFileFullName);
            var fileName = Path.Combine(rootPath, "appsettings.json");

            var builder = new ConfigurationBuilder();
            if (File.Exists(fileName))
            {
                var connectionString = builder
                    .AddJsonFile(fileName, optional: false)
                    .Build()
                    .GetConnectionString("WidDbServer");
                return $"Initial Catalog=SocWidUpdates;{connectionString}";
            }
            else
            {
                return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidUpdates; Server=localhost";
                //return @"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidUpdates; Server=DESKTOP-FT79FOI\SQLEXPRESS";
                //return @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidUpdates; Server=89.184.65.168\IPSDATA,60675";
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidAdmin; Server=89.184.65.168\IPSDATA,60675");
            //optionsBuilder.UseSqlServer(@"Persist Security Info=False;Trusted_Connection=yes;Initial Catalog = SocWidUpdates; Server=DESKTOP-FT79FOI\SQLEXPRESS");
            var connectionString = GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DscRecType>().HasKey(x => x.Code);
            modelBuilder.Entity<DscRecField>().HasKey(x => new { x.RecTypeCode, x.SeqNr });
            modelBuilder.Entity<DscFieldColName>() .HasKey(x => x.FieldName);
            modelBuilder.Entity<DscFmtInfo>().HasKey(x => x.Fmt);
            modelBuilder.Entity<UpdFile>().HasKey(x => x.Id);
            modelBuilder.Entity<WrkAffectedRecord>().HasNoKey();

            modelBuilder.Entity<DscRecField>().HasOne(x => x.RecType).WithMany(x => x.RecFields).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecAck>().HasOne(x => x.UpdFile).WithMany(x => x.RecAckLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecAlt>().HasOne(x => x.UpdFile).WithMany(x => x.RecAltLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecCom>().HasOne(x => x.UpdFile).WithMany(x => x.RecComLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecCon>().HasOne(x => x.UpdFile).WithMany(x => x.RecConLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecDel>().HasOne(x => x.UpdFile).WithMany(x => x.RecDelLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecEwt>().HasOne(x => x.UpdFile).WithMany(x => x.RecEwtLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecInd>().HasOne(x => x.UpdFile).WithMany(x => x.RecIndLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecIns>().HasOne(x => x.UpdFile).WithMany(x => x.RecInsLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecIsw>().HasOne(x => x.UpdFile).WithMany(x => x.RecIswLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecLnk>().HasOne(x => x.UpdFile).WithMany(x => x.RecLnkLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecMsg>().HasOne(x => x.UpdFile).WithMany(x => x.RecMsgLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecOip>().HasOne(x => x.UpdFile).WithMany(x => x.RecOipLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecOrn>().HasOne(x => x.UpdFile).WithMany(x => x.RecOrnLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecOsr>().HasOne(x => x.UpdFile).WithMany(x => x.RecOsrLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecPer>().HasOne(x => x.UpdFile).WithMany(x => x.RecPerLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecRes>().HasOne(x => x.UpdFile).WithMany(x => x.RecResLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecSip>().HasOne(x => x.UpdFile).WithMany(x => x.RecSipLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecSoc>().HasOne(x => x.UpdFile).WithMany(x => x.RecSocLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecSsr>().HasOne(x => x.UpdFile).WithMany(x => x.RecSsrLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecTtu>().HasOne(x => x.UpdFile).WithMany(x => x.RecTtuLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecVer>().HasOne(x => x.UpdFile).WithMany(x => x.RecVerLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecWia>().HasOne(x => x.UpdFile).WithMany(x => x.RecWiaLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecWiu>().HasOne(x => x.UpdFile).WithMany(x => x.RecWiuLst).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RecWpl>().HasOne(x => x.UpdFile).WithMany(x => x.RecWplLst).OnDelete(DeleteBehavior.Cascade);


            modelBuilder
                .Entity<DscRecType>()
                .HasData(new DscRecType[]
                {
                        new DscRecType { Code = "WIA", Nr = "6.01", Dsc = "Work Information Add"                         },
                        new DscRecType { Code = "WIU", Nr = "6.02", Dsc = "Work Information Update"                      },
                        new DscRecType { Code = "SOC", Nr = "6.03", Dsc = "Society Notification"                         },
                        new DscRecType { Code = "TTU", Nr = "6.04", Dsc = "Work Title Update"                            },
                        new DscRecType { Code = "CON", Nr = "6.05", Dsc = "Conflict Notification"                        },
                        new DscRecType { Code = "RES", Nr = "6.06", Dsc = "Notification of Resolution of Conflict"       },
                        new DscRecType { Code = "DEL", Nr = "6.07", Dsc = "Delete Transaction"                           },
                        new DscRecType { Code = "ACK", Nr = "6.08", Dsc = "Acknowledgment of Transaction"                },
                        new DscRecType { Code = "ISW", Nr = "7.01", Dsc = "Notification of Additional ISWC"              },
                        new DscRecType { Code = "LNK", Nr = "7.02", Dsc = "Notification of Work merged to its Duplicate" },
                        new DscRecType { Code = "SIP", Nr = "7.03", Dsc = "Interested Party Controlled By Submitter"     },
                        new DscRecType { Code = "OIP", Nr = "7.04", Dsc = "Other Interested Party"                       },
                        new DscRecType { Code = "SSR", Nr = "7.05", Dsc = "Shares Controlled by Submitter"               },
                        new DscRecType { Code = "OSR", Nr = "7.06", Dsc = "Other Shares"                                 },
                        new DscRecType { Code = "WPL", Nr = "7.07", Dsc = "Writer Publisher Link"                        },
                        new DscRecType { Code = "ALT", Nr = "7.08", Dsc = "Alternate Title"                              },
                        new DscRecType { Code = "EWT", Nr = "7.09", Dsc = "Entire Work Title for Excerpts"               },
                        new DscRecType { Code = "VER", Nr = "7.10", Dsc = "Original Work Title for Versions"             },
                        new DscRecType { Code = "PER", Nr = "7.11", Dsc = "Performing Artist"                            },
                        new DscRecType { Code = "ORN", Nr = "7.12", Dsc = "Work Origin"                                  },
                        new DscRecType { Code = "INS", Nr = "7.13", Dsc = "Instrumentation Summary"                      },
                        new DscRecType { Code = "IND", Nr = "7.14", Dsc = "Instrumentation Detail"                       },
                        new DscRecType { Code = "COM", Nr = "7.15", Dsc = "Component"                                    },
                        new DscRecType { Code = "MSG", Nr = "7.16", Dsc = "Message"                                      },
                });

            modelBuilder
                .Entity<DscRecField>()
                .HasData(new DscRecField[]
                {
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = ACK (Acknowledgment of Transaction)",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "Always set to 00000000.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 4, Field = "Creation Date", Start = 20, Size = 8, Fmt = 'D', Req = 'M', Rules = "1,2", Dsc = "The Creation Date of the original file that contained the transaction which this ACK applies to.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 5, Field = "Creation Time", Start = 28, Size = 6, Fmt = 'T', Req = 'M', Rules = "1,2", Dsc = "The Creation Time of the original file that contained the transaction which this ACK applies to.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 6, Field = "Original Group Number", Start = 34, Size = 5, Fmt = 'N', Req = 'M', Rules = "2", Dsc = "The Group Number within which the original transaction that this ACK applies to was located.  Note that if the ACK is a result of a HDR or TRL record problem, set this field to zeroes.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 7, Field = "Original Transaction Sequence #", Start = 39, Size = 8, Fmt = 'N', Req = 'M', Rules = "2", Dsc = "The Transaction Sequence # of the original transaction that this ACK applies to. Note that if the ACK is a result of a HDR or TRL record problem, set this field to zeroes.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 8, Field = "Original Transaction Type", Start = 47, Size = 3, Fmt = 'L', Req = 'M', Rules = "", Dsc = "The Transaction Type of the original transaction that this ACK applies to. Note that if the ACK is a result of a HDR or TRL record problem, set this field to HDR or TRL (whichever is applicable).",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 9, Field = "Creation Title", Start = 50, Size = 60, Fmt = 'A', Req = 'C', Rules = "4", Dsc = "The creation title as delivered by the submitter (i.e. the title of the musical work or audio visual production).  This field is required if the ACK is in response to a transaction.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 10, Field = "Submitter Creation #", Start = 110, Size = 20, Fmt = 'A', Req = 'C', Rules = "4,5", Dsc = "The unique identifier assigned by the submitter to this work. This field is required if the ACK is in response to a transaction.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 11, Field = "Recipient Creation #", Start = 130, Size = 20, Fmt = 'A', Req = 'O', Rules = "6", Dsc = "The preferred ISWC assigned to this work as confirmed by the CSI.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 12, Field = "Processing Date", Start = 150, Size = 8, Fmt = 'D', Req = 'M', Rules = "7", Dsc = "The date this transaction or file was formally processed by the recipient.",  },
                    new DscRecField { RecTypeCode = "ACK", SeqNr = 13, Field = "Transaction Status", Start = 158, Size = 2, Fmt = 'L', Req = 'M', Rules = "8", Dsc = "The current status of this transaction.  Values for this field reside in the Transaction Status Table.",  },
                    new DscRecField { RecTypeCode = "ALT", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = ALT (Alternate Title)",  },
                    new DscRecField { RecTypeCode = "ALT", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "ALT", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "ALT", SeqNr = 4, Field = "Alternate Title", Start = 20, Size = 60, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "AKA or pseudonym of the work title.",  },
                    new DscRecField { RecTypeCode = "ALT", SeqNr = 5, Field = "Title Type", Start = 80, Size = 3, Fmt = 'L', Req = 'M', Rules = "2", Dsc = "Indicates the type of alternate title presented on this record.  These values reside in the Title Type Table.",  },
                    new DscRecField { RecTypeCode = "ALT", SeqNr = 6, Field = "Language Code", Start = 83, Size = 2, Fmt = 'L', Req = 'O', Rules = "3", Dsc = "The Code representing the language that this alternate title has been translated into.  These values reside in the Language Code Table.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = COM (Composite Component)",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 4, Field = "Title", Start = 20, Size = 60, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "The title of the original work from which a portion was taken to include in the composite.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 5, Field = "ISWC of Component", Start = 80, Size = 11, Fmt = 'L', Req = 'O', Rules = "2", Dsc = "The International Standard Work Code assigned to the original work from which a portion was taken and included in this composite work.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 6, Field = "Submitter Work #", Start = 91, Size = 14, Fmt = 'A', Req = 'O', Rules = "", Dsc = "The number that the submitting publisher uses to refer to this  component.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 7, Field = "Duration", Start = 105, Size = 6, Fmt = 'T', Req = 'O', Rules = "3", Dsc = "The duration of the individual  component within the composite work.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 8, Field = "Writer 1: Last Name", Start = 111, Size = 45, Fmt = 'A', Req = 'M', Rules = "4", Dsc = "Last name of the first writer of this component. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 9, Field = "Writer 1: First Name", Start = 156, Size = 30, Fmt = 'A', Req = 'O', Rules = "", Dsc = "First name of the first writer of this component.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 10, Field = "Filler1", Start = 186, Size = 9, Fmt = ' ', Req = ' ', Rules = " ", Dsc = "No longer used",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 11, Field = "Writer 2: Last Name", Start = 195, Size = 45, Fmt = 'A', Req = 'O', Rules = "", Dsc = "Last name of the second writer of this component. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 12, Field = "Writer 2: First Name", Start = 240, Size = 30, Fmt = 'A', Req = 'O', Rules = "", Dsc = "First name of the second writer of this component.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 13, Field = "Filler2", Start = 270, Size = 9, Fmt = ' ', Req = ' ', Rules = " ", Dsc = "No longer used",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 14, Field = "Writer 1: IPI Name #", Start = 279, Size = 11, Fmt = 'N', Req = 'O', Rules = "6", Dsc = "IPI Name # of the first writer of this component.",  },
                    new DscRecField { RecTypeCode = "COM", SeqNr = 15, Field = "Writer 2: IPI Name #", Start = 290, Size = 11, Fmt = 'N', Req = 'O', Rules = "6", Dsc = "IPI Name # of the second writer of this component.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = CON (Conflict Notification)",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "Always set to 00000000.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 4, Field = "ISWC", Start = 20, Size = 11, Fmt = 'L', Req = 'C', Rules = "1,3,4", Dsc = "ISWC of title to be marked in conflict.  This field is required if WI Code is not entered.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 5, Field = "WI Code", Start = 31, Size = 10, Fmt = 'N', Req = 'C', Rules = "2,3,4", Dsc = "WI Code of title to be marked in conflict.  This field is required if ISWC is not entered.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 6, Field = "Conflict Reason Code", Start = 41, Size = 3, Fmt = 'L', Req = 'M', Rules = "7", Dsc = "The reason that this work is being marked in conflict.  Values for this field reside in the Conflict Reason Code Table.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 7, Field = "Type of Right", Start = 44, Size = 3, Fmt = 'L', Req = 'M', Rules = "6", Dsc = "The type of right for which this conflict exists. These values reside on the Type of Right Table.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 8, Field = "Work Title", Start = 47, Size = 60, Fmt = 'A', Req = 'M', Rules = "5", Dsc = "The title of the work to be marked in conflict.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 9, Field = "Conflict Note", Start = 107, Size = 60, Fmt = 'A', Req = 'O', Rules = "", Dsc = "A description of the issue creating the conflict.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 10, Field = "Contact Name", Start = 167, Size = 30, Fmt = 'A', Req = 'O', Rules = "8", Dsc = "The name of a business contact person at the organization that originated this transaction.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 11, Field = "Contact ID", Start = 197, Size = 10, Fmt = 'A', Req = 'O', Rules = "", Dsc = "An identifier associated with the contact person at the organization that originated this transaction.",  },
                    new DscRecField { RecTypeCode = "CON", SeqNr = 12, Field = "Society Code", Start = 207, Size = 3, Fmt = 'N', Req = 'M', Rules = "9", Dsc = "The code representing the society that submitted this conflict.  These values reside on the Society Code Table.",  },
                    new DscRecField { RecTypeCode = "DEL", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = DEL ",  },
                    new DscRecField { RecTypeCode = "DEL", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "DEL", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "DEL", SeqNr = 4, Field = "Submitter Work #", Start = 20, Size = 14, Fmt = 'A', Req = 'M', Rules = "1,2", Dsc = "Submitter Work # of work to delete. ",  },
                    new DscRecField { RecTypeCode = "DEL", SeqNr = 5, Field = "ISWC", Start = 34, Size = 11, Fmt = 'A', Req = 'O', Rules = "", Dsc = "ISWC of work to delete.",  },
                    new DscRecField { RecTypeCode = "DEL", SeqNr = 6, Field = "WIC ", Start = 45, Size = 10, Fmt = 'N', Req = 'O', Rules = "", Dsc = "WI Code of work to delete. ",  },
                    new DscRecField { RecTypeCode = "DEL", SeqNr = 7, Field = "Right Type", Start = 55, Size = 3, Fmt = 'A', Req = 'O', Rules = "6", Dsc = "Right type(s) controlled by submitter to delete. (PER, MEC or spaces).",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = EWT (Entire Work Title for Excerpts)",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 4, Field = "Entire Work Title", Start = 20, Size = 60, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "The title of the entire work from which this excerpt has been derived.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 5, Field = "ISWC of Entire Work", Start = 80, Size = 11, Fmt = 'A', Req = 'O', Rules = "2,5", Dsc = "The International Standard Work Code assigned to the work from which this excerpt has been derived.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 6, Field = "Language Code", Start = 91, Size = 2, Fmt = 'L', Req = 'O', Rules = "3", Dsc = "The Code defining the language in which the entire was originally written.  These values reside in the Language Code Table.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 7, Field = "Writer Last Name", Start = 93, Size = 45, Fmt = 'A', Req = 'O', Rules = "", Dsc = "Last name of the original writer/composer of the work from which this excerpt has been taken. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 8, Field = "Writer First Name", Start = 138, Size = 30, Fmt = 'A', Req = 'O', Rules = "", Dsc = "First name of the original writer/composer of the work from which this excerpt has been taken.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 9, Field = "Source", Start = 168, Size = 60, Fmt = 'A', Req = 'O', Rules = "", Dsc = "A description of the source from which the work was obtained.",  },
                    new DscRecField { RecTypeCode = "EWT", SeqNr = 10, Field = "WI Code", Start = 228, Size = 10, Fmt = 'N', Req = 'O', Rules = "4,5", Dsc = "The WI Code assigned to the work from which this excerpt has been derived.",  },
                    new DscRecField { RecTypeCode = "IND", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = IND (Instrumentation Detail)",  },
                    new DscRecField { RecTypeCode = "IND", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "IND", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "IND", SeqNr = 4, Field = "Instrument Code", Start = 20, Size = 3, Fmt = 'L', Req = 'M', Rules = "1", Dsc = "Indicates the use of a specific instrument in this version of instrumentation.  These values reside in the Instrument Table.",  },
                    new DscRecField { RecTypeCode = "IND", SeqNr = 5, Field = "Number of Players", Start = 23, Size = 3, Fmt = 'N', Req = 'M', Rules = "2", Dsc = "Indicates the number of players for the above instrument.  Note if the number of players is not a significant detail enter zero.",  },
                    new DscRecField { RecTypeCode = "INS", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = INS (Instrumentation Summary)",  },
                    new DscRecField { RecTypeCode = "INS", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "INS", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "INS", SeqNr = 4, Field = "Number of Voices", Start = 20, Size = 3, Fmt = 'N', Req = 'M', Rules = "1", Dsc = "Indicates the number of independent parts on this work.",  },
                    new DscRecField { RecTypeCode = "INS", SeqNr = 5, Field = "Standard Instrumentation Type", Start = 23, Size = 3, Fmt = 'L', Req = 'C', Rules = "2,3", Dsc = "Describes instrumentation if standard instrumentation is used on this work. Note that this field is required if IND records are not entered or if Instrumentation Description is blank.  These values reside in the Standard Instrumentation Table.",  },
                    new DscRecField { RecTypeCode = "INS", SeqNr = 6, Field = "Instrumentation Description", Start = 26, Size = 50, Fmt = 'A', Req = 'C', Rules = "", Dsc = "Describes instrumentation if non-standard instrumentation is used on this work. Note that this field is required if IND records are not entered or if Standard Instrumentation Type is blank.",  },
                    new DscRecField { RecTypeCode = "ISW", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = ISW (Notification of Additional ISWC)",  },
                    new DscRecField { RecTypeCode = "ISW", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "ISW", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "ISW", SeqNr = 4, Field = "Creation Title", Start = 20, Size = 60, Fmt = 'A', Req = 'C', Rules = "1", Dsc = "The creation title as delivered by the submitter (i.e. the title of the musical work).",  },
                    new DscRecField { RecTypeCode = "ISW", SeqNr = 5, Field = "Archived ISWC", Start = 80, Size = 11, Fmt = 'A', Req = 'M', Rules = "2", Dsc = "An Archived ISWC assigned to this musical work. ",  },
                    new DscRecField { RecTypeCode = "LNK", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = LNK (Notification of Work Merged to its Duplicate)",  },
                    new DscRecField { RecTypeCode = "LNK", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "LNK", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "LNK", SeqNr = 4, Field = "WIC of Newly Merged Work", Start = 20, Size = 10, Fmt = 'N', Req = 'M', Rules = "1", Dsc = "The WIC assigned to the newly merged musical work. ",  },
                    new DscRecField { RecTypeCode = "LNK", SeqNr = 5, Field = "WIC of Deleted Work", Start = 30, Size = 10, Fmt = 'N', Req = 'M', Rules = "2", Dsc = "The WIC assigned to the duplicate work that is being deleted.",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = MSG (Message)",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 4, Field = "Message Type", Start = 20, Size = 1, Fmt = 'L', Req = 'M', Rules = "1", Dsc = "Indicates whether this information is a warning, error, or for information only.  Values are F = Field Rejected, R = Record Rejected, T = Transaction Rejected, G = Group Rejected, E = Entire File Rejected",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 5, Field = "Original Record Sequence ", Start = 21, Size = 8, Fmt = 'N', Req = 'M', Rules = "2", Dsc = "The Record Sequence Number within the packet associated with this acknowledgment that caused the generation of this message.",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 6, Field = "Original Record Type", Start = 29, Size = 3, Fmt = 'A', Req = 'M', Rules = "", Dsc = "The record type within the original transaction that caused generation of this message.",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 7, Field = "Message Level", Start = 32, Size = 1, Fmt = 'L', Req = 'M', Rules = "3", Dsc = "The level of editing that was responsible for generation of this message.  Values are E = Entire File, G = Group, T = Transaction, R = Record, F = Field.",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 8, Field = "Condition Number", Start = 33, Size = 3, Fmt = 'A', Req = 'M', Rules = "", Dsc = "Identifies the specific edit condition that generated this message.  Note that the combination of Record Type, Message Level, and Condition Number points back to a condition within this document.",  },
                    new DscRecField { RecTypeCode = "MSG", SeqNr = 9, Field = "Message Text", Start = 36, Size = 150, Fmt = 'A', Req = 'M', Rules = "4", Dsc = "The text associated with this message.",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A,2", Dsc = "Set Record Type = SIP (Interested Party Controlled by Submitter) or OIP (Other Interested Party)",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 4, Field = "Filler1", Start = 20, Size = 9, Fmt = ' ', Req = ' ', Rules = "", Dsc = "No longer in use",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 5, Field = "Interested Party #", Start = 29, Size = 9, Fmt = 'A', Req = 'C', Rules = "2,3", Dsc = "Submitters unique identifier for this IP.  This field is required for record type SIP and optional for record type OIP.",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 6, Field = "IP Name", Start = 38, Size = 45, Fmt = 'A', Req = 'M', Rules = "4", Dsc = "For publisher IP’s, enter the name of the publisher.  For writer IP’s, enter the writers last name.",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 7, Field = "IP First Name", Start = 83, Size = 30, Fmt = 'O', Req = 'O', Rules = "4", Dsc = "For writer IP’s, enter the writers first name.",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 8, Field = "IP Role", Start = 113, Size = 2, Fmt = 'L', Req = 'M', Rules = "5", Dsc = "Code defining this interested party’s role in this work.   These values reside on the Works IP Role  Table.",  },
                    new DscRecField { RecTypeCode = "OIP", SeqNr = 9, Field = "IPI Name #", Start = 115, Size = 11, Fmt = 'L', Req = 'M', Rules = "1,7,8,9", Dsc = "The IPI name number assigned to this IP.",  },
                    new DscRecField { RecTypeCode = "ORN", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = ORN (Work Origin)",  },
                    new DscRecField { RecTypeCode = "ORN", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "ORN", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "ORN", SeqNr = 4, Field = "Intended Purpose", Start = 20, Size = 3, Fmt = 'L', Req = 'M', Rules = "1", Dsc = "Indicates the type of production from which this work originated.  These values reside in the Intended Purpose Table.",  },
                    new DscRecField { RecTypeCode = "ORN", SeqNr = 5, Field = "Production Title", Start = 23, Size = 60, Fmt = 'A', Req = 'M', Rules = "2", Dsc = "Name of the production or library from which this work originated.",  },
                    new DscRecField { RecTypeCode = "ORN", SeqNr = 6, Field = "CD Identifier", Start = 83, Size = 15, Fmt = 'A', Req = 'C', Rules = "3", Dsc = "If Intended Purpose is equal to LIB (Library Work), enter the identifier associated with the CD upon which the work appears",  },
                    new DscRecField { RecTypeCode = "ORN", SeqNr = 7, Field = "Cut Number", Start = 98, Size = 4, Fmt = 'N', Req = 'C', Rules = "3", Dsc = "If Intended Purpose is equal to LIB (Library Work), enter the track number on the CD Identifier where the work appears.  This field is required when CD Identifier is entered.",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = SSR (Shares Controlled by Submitter) or OSR (Other Shares)",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 4, Field = "Filler3", Start = 20, Size = 9, Fmt = ' ', Req = ' ', Rules = "", Dsc = "No longer in use",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 5, Field = "Type of Right", Start = 29, Size = 3, Fmt = 'L', Req = 'M', Rules = "2", Dsc = "The type of right for which these shares exist. These values reside on the Type of Right Table.",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 6, Field = "Shares", Start = 32, Size = 5, Fmt = 'N', Req = 'M', Rules = "3", Dsc = "The shares assigned to this IP for this type of right.  Shares should be formatted as 999V99 (implied decimal point).  For example, 25.87% would be entered as ‘02587’.",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 7, Field = "IPI Name #", Start = 37, Size = 11, Fmt = 'N', Req = 'M', Rules = "1,4", Dsc = "The IPI name number assigned to this IP.",  },
                    new DscRecField { RecTypeCode = "OSR", SeqNr = 8, Field = "Affiliation", Start = 48, Size = 3, Fmt = 'L', Req = 'O', Rules = "", Dsc = "The society to which this IP belongs for this right.",  },
                    new DscRecField { RecTypeCode = "PER", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = PER (Performing Artist)",  },
                    new DscRecField { RecTypeCode = "PER", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "PER", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "PER", SeqNr = 4, Field = "Performing Artist Last Name", Start = 20, Size = 45, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "Last name of a person or name of a group that has performed the work on a recording or in public.",  },
                    new DscRecField { RecTypeCode = "PER", SeqNr = 5, Field = "Performing Artist First Name", Start = 65, Size = 30, Fmt = 'A', Req = 'O', Rules = "", Dsc = "First name associated with the performing artist identified in the previous field.",  },
                    new DscRecField { RecTypeCode = "PER", SeqNr = 6, Field = "Filler4", Start = 95, Size = 9, Fmt = ' ', Req = ' ', Rules = " ", Dsc = "No longer used",  },
                    new DscRecField { RecTypeCode = "PER", SeqNr = 7, Field = "Performing Artist IPI Name #", Start = 104, Size = 11, Fmt = 'L', Req = 'O', Rules = "2", Dsc = "The IPI Name # corresponding to this performing artist.  Values reside in the IPI System.",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = RES (Conflict Resolution)",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "Always set to 00000000.",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 4, Field = "ISWC", Start = 20, Size = 11, Fmt = 'L', Req = 'C', Rules = "1,3,4,5", Dsc = "ISWC of title to be marked resolved.  This field is required if WI Code is not entered.",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 5, Field = "WI Code", Start = 31, Size = 10, Fmt = 'N', Req = 'C', Rules = "2,3,4,5", Dsc = "WI Code of title to be marked resolved.  This field is required if ISWC is not entered.",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 6, Field = "Type of Right", Start = 41, Size = 3, Fmt = 'L', Req = 'M', Rules = "8", Dsc = "The type of right for which this conflict exists. These values reside on the Type of Right Table.",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 7, Field = "Work Title", Start = 44, Size = 60, Fmt = 'A', Req = 'M', Rules = "5", Dsc = "The title of the work to be marked resolved.",  },
                    new DscRecField { RecTypeCode = "RES", SeqNr = 8, Field = "Society Code", Start = 104, Size = 3, Fmt = 'N', Req = 'M', Rules = "6", Dsc = "The code representing the society that submitted this resolution.  These values reside on the Society Code Table.",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A,2", Dsc = "Set Record Type = SIP (Interested Party Controlled by Submitter) or OIP (Other Interested Party)",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 4, Field = "Filler5", Start = 20, Size = 9, Fmt = ' ', Req = ' ', Rules = "", Dsc = "No longer in use",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 5, Field = "Interested Party #", Start = 29, Size = 9, Fmt = 'A', Req = 'C', Rules = "2,3", Dsc = "Submitters unique identifier for this IP.  This field is required for record type SIP and optional for record type OIP.",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 6, Field = "IP Name", Start = 38, Size = 45, Fmt = 'A', Req = 'M', Rules = "4", Dsc = "For publisher IP’s, enter the name of the publisher.  For writer IP’s, enter the writers last name.",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 7, Field = "IP First Name", Start = 83, Size = 30, Fmt = 'O', Req = 'O', Rules = "4", Dsc = "For writer IP’s, enter the writers first name.",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 8, Field = "IP Role", Start = 113, Size = 2, Fmt = 'L', Req = 'M', Rules = "5", Dsc = "Code defining this interested party’s role in this work.   These values reside on the Works IP Role  Table.",  },
                    new DscRecField { RecTypeCode = "SIP", SeqNr = 9, Field = "IPI Name #", Start = 115, Size = 11, Fmt = 'L', Req = 'M', Rules = "1,7,8,9", Dsc = "The IPI name number assigned to this IP.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = WIA (Work Information Add) for new registrations, WIU (Work Information Update) for revisions, or SOC (Society Notification)",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "Always set to 00000000.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 4, Field = "Work Title", Start = 20, Size = 60, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "Name/Title of the work.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 5, Field = "Language Code", Start = 80, Size = 2, Fmt = 'L', Req = 'O', Rules = "2", Dsc = "The Code representing the language of this title.  These values reside in the Language Code Table.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 6, Field = "Submitter Work #", Start = 82, Size = 14, Fmt = 'A', Req = 'M', Rules = "3", Dsc = "Number assigned to the work by the party submitting the file.  This number must be unique for the submitter.  On files sent to the WID it is the society work #.  On SOC transactions it is the work # of the society that last submitted the work.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 7, Field = "ISWC", Start = 96, Size = 11, Fmt = 'A', Req = 'O', Rules = "4,18", Dsc = "The preferred International Standard Work Code assigned to this work as confirmed by the CSI.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 8, Field = "Copyright Date", Start = 107, Size = 8, Fmt = 'D', Req = 'O', Rules = "5", Dsc = "Original copyright date of the work.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 9, Field = "Copyright Number", Start = 115, Size = 12, Fmt = 'A', Req = 'O', Rules = "", Dsc = "Original copyright number of the work.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 10, Field = "Musical Work Distribution Category", Start = 127, Size = 3, Fmt = 'L', Req = 'M', Rules = "6,7", Dsc = "Describes the type of music as it applies to special distribution rules.  Values for this field reside in the Musical Work Distribution Category Table. ",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 11, Field = "Duration", Start = 130, Size = 6, Fmt = 'T', Req = 'C', Rules = "8", Dsc = "Duration of the work in hours, minutes, and seconds.  This field must be greater than zero if Musical Work Distribution Category is equal to SER.  ",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 12, Field = "Recorded Indicator", Start = 136, Size = 1, Fmt = 'F', Req = 'M', Rules = "9", Dsc = "Indicates whether or not the work has ever been recorded.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 13, Field = "Text Music Relationship", Start = 137, Size = 3, Fmt = 'A', Req = 'O', Rules = "10", Dsc = "Indicates whether this work contains music, text, and/or both.  Values are MTX = Both Music and Text, MUS = Music only, TXT = Text only.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 14, Field = "Composite Type", Start = 140, Size = 3, Fmt = 'L', Req = 'O', Rules = "11", Dsc = "If this is a composite work, this field will indicate the type of composite.  Values reside in the Composite Type Table.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 15, Field = "Version Type", Start = 143, Size = 3, Fmt = 'L', Req = 'M', Rules = "12,14,15", Dsc = "Indicates relationships between this work and other works.  Note that this field is used to indicate whether or not this work is an arrangement.  Values reside in the Version Type Table.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 16, Field = "Excerpt Type", Start = 146, Size = 3, Fmt = 'L', Req = 'O', Rules = "13", Dsc = "If this is an excerpt, this field will indicate the type of excerpt.  Values reside in the Excerpt Type Table.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 17, Field = "Music Arrangement ", Start = 149, Size = 3, Fmt = 'L', Req = 'C', Rules = "14", Dsc = "If Version Type is equal to ‘MOD’, this field indicates the type of music arrangement.  Values reside in the Music Arrangement Table.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 18, Field = "Lyric Adaptation", Start = 152, Size = 3, Fmt = 'L', Req = 'C', Rules = "15", Dsc = "If Version Type is equal to ‘MOD’, this field indicates the type of lyric adaptation.  Values reside in the Lyric Adaptation Table.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 19, Field = "WI Code", Start = 155, Size = 10, Fmt = 'N', Req = 'C', Rules = "16,17,18,19", Dsc = "The unique code used by the WI Center to identify this work.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 20, Field = "Update date ", Start = 165, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This field contains the date of the last update done on the corresponding Work in the legacy system  This field is mandatory/optional in case you use the CIS-Net Dataloader.",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 21, Field = "First sending date to CIS-Net", Start = 173, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This date indicates the ' First sending date to CIS-Net'.. This field is mandatory/optional in case you use the CIS-Net Dataloader",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 22, Field = "Last sending date to CIS-Net", Start = 181, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This date indicates the 'Last sending date to CIS-Net '.  This field is mandatory/optional in case you use the CIS-Net Dataloader",  },
                    new DscRecField { RecTypeCode = "SOC", SeqNr = 23, Field = "Society Work type", Start = 189, Size = 3, Fmt = 'L', Req = 'C', Rules = "", Dsc = "Indicates if it is a domestic work ('DOM') or an international work ('INT').  This field is required by the CIS-Net Data loader.",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = SSR (Shares Controlled by Submitter) or OSR (Other Shares)",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 4, Field = "Filler6", Start = 20, Size = 9, Fmt = ' ', Req = ' ', Rules = "", Dsc = "No longer in use",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 5, Field = "Type of Right", Start = 29, Size = 3, Fmt = 'L', Req = 'M', Rules = "2", Dsc = "The type of right for which these shares exist. These values reside on the Type of Right Table.",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 6, Field = "Shares", Start = 32, Size = 5, Fmt = 'N', Req = 'M', Rules = "3", Dsc = "The shares assigned to this IP for this type of right.  Shares should be formatted as 999V99 (implied decimal point).  For example, 25.87% would be entered as ‘02587’.",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 7, Field = "IPI Name #", Start = 37, Size = 11, Fmt = 'N', Req = 'M', Rules = "1,4", Dsc = "The IPI name number assigned to this IP.",  },
                    new DscRecField { RecTypeCode = "SSR", SeqNr = 8, Field = "Affiliation", Start = 48, Size = 3, Fmt = 'L', Req = 'O', Rules = "", Dsc = "The society to which this IP belongs for this right.",  },
                    new DscRecField { RecTypeCode = "TTU", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = TTU (Work Title Update)",  },
                    new DscRecField { RecTypeCode = "TTU", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.",  },
                    new DscRecField { RecTypeCode = "TTU", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "Always set to 00000000.",  },
                    new DscRecField { RecTypeCode = "TTU", SeqNr = 4, Field = "ISWC", Start = 20, Size = 11, Fmt = 'L', Req = 'C', Rules = "1,3,5", Dsc = "ISWC of title to be changed.  This field is required if WI Code is not entered.",  },
                    new DscRecField { RecTypeCode = "TTU", SeqNr = 5, Field = "WI Code", Start = 31, Size = 10, Fmt = 'N', Req = 'C', Rules = "2,3,5", Dsc = "WI Code of title to be changed.  This field is required if ISWC is not entered.",  },
                    new DscRecField { RecTypeCode = "TTU", SeqNr = 6, Field = "Original Work Title", Start = 41, Size = 60, Fmt = 'A', Req = 'M', Rules = "5", Dsc = "The original title of the work.",  },
                    new DscRecField { RecTypeCode = "TTU", SeqNr = 7, Field = "New Work Title", Start = 101, Size = 60, Fmt = 'A', Req = 'M', Rules = "6", Dsc = "The new title of the work",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = VER (Original Work Title for Versions)",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 4, Field = "Original Work Title", Start = 20, Size = 60, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "Original title of the work from which this version was derived.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 5, Field = "ISWC of Original Work", Start = 80, Size = 11, Fmt = 'A', Req = 'O', Rules = "2,5", Dsc = "The International Standard Work Code assigned to the work from which this version has been derived.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 6, Field = "Language Code", Start = 91, Size = 2, Fmt = 'L', Req = 'O', Rules = "3", Dsc = "The Code defining the language in which the work was originally written.  These values reside in the Language Code Table.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 7, Field = "Writer Last Name", Start = 93, Size = 45, Fmt = 'A', Req = 'O', Rules = "", Dsc = "Last name of the original writer/composer of the work from which this version has been derived. Note that if the submitter does not have the ability to split first and last names, the entire name should be entered in this field in the format “LastName, FirstName” including the comma after the last name.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 8, Field = "Writer First Name", Start = 138, Size = 30, Fmt = 'A', Req = 'O', Rules = "", Dsc = "First name of the original writer/composer of the work from which this version has been derived.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 9, Field = "Source", Start = 168, Size = 60, Fmt = 'A', Req = 'O', Rules = "", Dsc = "A description of the source from which the work was obtained.",  },
                    new DscRecField { RecTypeCode = "VER", SeqNr = 10, Field = "WI Code", Start = 228, Size = 10, Fmt = 'N', Req = 'O', Rules = "4,5", Dsc = "The WI Code assigned to the work from which this version has been derived.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = WIA (Work Information Add) for new registrations, WIU (Work Information Update) for revisions, or SOC (Society Notification)",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "Always set to 00000000.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 4, Field = "Work Title", Start = 20, Size = 60, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "Name/Title of the work.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 5, Field = "Language Code", Start = 80, Size = 2, Fmt = 'L', Req = 'O', Rules = "2", Dsc = "The Code representing the language of this title.  These values reside in the Language Code Table.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 6, Field = "Submitter Work #", Start = 82, Size = 14, Fmt = 'A', Req = 'M', Rules = "3", Dsc = "Number assigned to the work by the party submitting the file.  This number must be unique for the submitter.  On files sent to the WID it is the society work #.  On SOC transactions it is the work # of the society that last submitted the work.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 7, Field = "ISWC", Start = 96, Size = 11, Fmt = 'A', Req = 'O', Rules = "4,18", Dsc = "The preferred International Standard Work Code assigned to this work as confirmed by the CSI.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 8, Field = "Copyright Date", Start = 107, Size = 8, Fmt = 'D', Req = 'O', Rules = "5", Dsc = "Original copyright date of the work.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 9, Field = "Copyright Number", Start = 115, Size = 12, Fmt = 'A', Req = 'O', Rules = "", Dsc = "Original copyright number of the work.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 10, Field = "Musical Work Distribution Category", Start = 127, Size = 3, Fmt = 'L', Req = 'M', Rules = "6,7", Dsc = "Describes the type of music as it applies to special distribution rules.  Values for this field reside in the Musical Work Distribution Category Table. ",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 11, Field = "Duration", Start = 130, Size = 6, Fmt = 'T', Req = 'C', Rules = "8", Dsc = "Duration of the work in hours, minutes, and seconds.  This field must be greater than zero if Musical Work Distribution Category is equal to SER.  ",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 12, Field = "Recorded Indicator", Start = 136, Size = 1, Fmt = 'F', Req = 'M', Rules = "9", Dsc = "Indicates whether or not the work has ever been recorded.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 13, Field = "Text Music Relationship", Start = 137, Size = 3, Fmt = 'A', Req = 'O', Rules = "10", Dsc = "Indicates whether this work contains music, text, and/or both.  Values are MTX = Both Music and Text, MUS = Music only, TXT = Text only.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 14, Field = "Composite Type", Start = 140, Size = 3, Fmt = 'L', Req = 'O', Rules = "11", Dsc = "If this is a composite work, this field will indicate the type of composite.  Values reside in the Composite Type Table.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 15, Field = "Version Type", Start = 143, Size = 3, Fmt = 'L', Req = 'M', Rules = "12,14,15", Dsc = "Indicates relationships between this work and other works.  Note that this field is used to indicate whether or not this work is an arrangement.  Values reside in the Version Type Table.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 16, Field = "Excerpt Type", Start = 146, Size = 3, Fmt = 'L', Req = 'O', Rules = "13", Dsc = "If this is an excerpt, this field will indicate the type of excerpt.  Values reside in the Excerpt Type Table.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 17, Field = "Music Arrangement ", Start = 149, Size = 3, Fmt = 'L', Req = 'C', Rules = "14", Dsc = "If Version Type is equal to ‘MOD’, this field indicates the type of music arrangement.  Values reside in the Music Arrangement Table.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 18, Field = "Lyric Adaptation", Start = 152, Size = 3, Fmt = 'L', Req = 'C', Rules = "15", Dsc = "If Version Type is equal to ‘MOD’, this field indicates the type of lyric adaptation.  Values reside in the Lyric Adaptation Table.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 19, Field = "WI Code", Start = 155, Size = 10, Fmt = 'N', Req = 'C', Rules = "16,17,18,19", Dsc = "The unique code used by the WI Center to identify this work.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 20, Field = "Update date ", Start = 165, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This field contains the date of the last update done on the corresponding Work in the legacy system  This field is mandatory/optional in case you use the CIS-Net Dataloader.",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 21, Field = "First sending date to CIS-Net", Start = 173, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This date indicates the ' First sending date to CIS-Net'.. This field is mandatory/optional in case you use the CIS-Net Dataloader",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 22, Field = "Last sending date to CIS-Net", Start = 181, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This date indicates the 'Last sending date to CIS-Net '.  This field is mandatory/optional in case you use the CIS-Net Dataloader",  },
                    new DscRecField { RecTypeCode = "WIA", SeqNr = 23, Field = "Society Work type", Start = 189, Size = 3, Fmt = 'L', Req = 'C', Rules = "", Dsc = "Indicates if it is a domestic work ('DOM') or an international work ('INT').  This field is required by the CIS-Net Data loader.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = WIA (Work Information Add) for new registrations, WIU (Work Information Update) for revisions, or SOC (Society Notification)",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "If this is the first transaction within a group, the Transaction Sequence # must be equal to 00000000. Otherwise, the Transaction Sequence # must be equal to the previous transaction header’s Transaction Sequence # incremented by 1.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "Always set to 00000000.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 4, Field = "Work Title", Start = 20, Size = 60, Fmt = 'A', Req = 'M', Rules = "1", Dsc = "Name/Title of the work.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 5, Field = "Language Code", Start = 80, Size = 2, Fmt = 'L', Req = 'O', Rules = "2", Dsc = "The Code representing the language of this title.  These values reside in the Language Code Table.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 6, Field = "Submitter Work #", Start = 82, Size = 14, Fmt = 'A', Req = 'M', Rules = "3", Dsc = "Number assigned to the work by the party submitting the file.  This number must be unique for the submitter.  On files sent to the WID it is the society work #.  On SOC transactions it is the work # of the society that last submitted the work.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 7, Field = "ISWC", Start = 96, Size = 11, Fmt = 'A', Req = 'O', Rules = "4,18", Dsc = "The preferred International Standard Work Code assigned to this work as confirmed by the CSI.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 8, Field = "Copyright Date", Start = 107, Size = 8, Fmt = 'D', Req = 'O', Rules = "5", Dsc = "Original copyright date of the work.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 9, Field = "Copyright Number", Start = 115, Size = 12, Fmt = 'A', Req = 'O', Rules = "", Dsc = "Original copyright number of the work.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 10, Field = "Musical Work Distribution Category", Start = 127, Size = 3, Fmt = 'L', Req = 'M', Rules = "6,7", Dsc = "Describes the type of music as it applies to special distribution rules.  Values for this field reside in the Musical Work Distribution Category Table. ",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 11, Field = "Duration", Start = 130, Size = 6, Fmt = 'T', Req = 'C', Rules = "8", Dsc = "Duration of the work in hours, minutes, and seconds.  This field must be greater than zero if Musical Work Distribution Category is equal to SER.  ",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 12, Field = "Recorded Indicator", Start = 136, Size = 1, Fmt = 'F', Req = 'M', Rules = "9", Dsc = "Indicates whether or not the work has ever been recorded.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 13, Field = "Text Music Relationship", Start = 137, Size = 3, Fmt = 'A', Req = 'O', Rules = "10", Dsc = "Indicates whether this work contains music, text, and/or both.  Values are MTX = Both Music and Text, MUS = Music only, TXT = Text only.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 14, Field = "Composite Type", Start = 140, Size = 3, Fmt = 'L', Req = 'O', Rules = "11", Dsc = "If this is a composite work, this field will indicate the type of composite.  Values reside in the Composite Type Table.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 15, Field = "Version Type", Start = 143, Size = 3, Fmt = 'L', Req = 'M', Rules = "12,14,15", Dsc = "Indicates relationships between this work and other works.  Note that this field is used to indicate whether or not this work is an arrangement.  Values reside in the Version Type Table.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 16, Field = "Excerpt Type", Start = 146, Size = 3, Fmt = 'L', Req = 'O', Rules = "13", Dsc = "If this is an excerpt, this field will indicate the type of excerpt.  Values reside in the Excerpt Type Table.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 17, Field = "Music Arrangement ", Start = 149, Size = 3, Fmt = 'L', Req = 'C', Rules = "14", Dsc = "If Version Type is equal to ‘MOD’, this field indicates the type of music arrangement.  Values reside in the Music Arrangement Table.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 18, Field = "Lyric Adaptation", Start = 152, Size = 3, Fmt = 'L', Req = 'C', Rules = "15", Dsc = "If Version Type is equal to ‘MOD’, this field indicates the type of lyric adaptation.  Values reside in the Lyric Adaptation Table.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 19, Field = "WI Code", Start = 155, Size = 10, Fmt = 'N', Req = 'C', Rules = "16,17,18,19", Dsc = "The unique code used by the WI Center to identify this work.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 20, Field = "Update date ", Start = 165, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This field contains the date of the last update done on the corresponding Work in the legacy system  This field is mandatory/optional in case you use the CIS-Net Dataloader.",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 21, Field = "First sending date to CIS-Net", Start = 173, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This date indicates the ' First sending date to CIS-Net'.. This field is mandatory/optional in case you use the CIS-Net Dataloader",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 22, Field = "Last sending date to CIS-Net", Start = 181, Size = 8, Fmt = 'N', Req = 'O', Rules = "", Dsc = "This date indicates the 'Last sending date to CIS-Net '.  This field is mandatory/optional in case you use the CIS-Net Dataloader",  },
                    new DscRecField { RecTypeCode = "WIU", SeqNr = 23, Field = "Society Work type", Start = 189, Size = 3, Fmt = 'L', Req = 'C', Rules = "", Dsc = "Indicates if it is a domestic work ('DOM') or an international work ('INT').  This field is required by the CIS-Net Data loader.",  },
                    new DscRecField { RecTypeCode = "WPL", SeqNr = 1, Field = "Record Type", Start = 1, Size = 3, Fmt = 'A', Req = 'M', Rules = "A", Dsc = "Set Record Type = WPL (Writer Publisher Link)",  },
                    new DscRecField { RecTypeCode = "WPL", SeqNr = 2, Field = "Transaction Sequence #", Start = 4, Size = 8, Fmt = 'N', Req = 'M', Rules = "B,C,D,G,H", Dsc = "The Transaction Sequence # of the previous transaction header.",  },
                    new DscRecField { RecTypeCode = "WPL", SeqNr = 3, Field = "Record Sequence #", Start = 12, Size = 8, Fmt = 'N', Req = 'M', Rules = "E,F", Dsc = "The Record Sequence # of the previous record written to the file incremented by 1.",  },
                    new DscRecField { RecTypeCode = "WPL", SeqNr = 4, Field = "Filler7", Start = 20, Size = 9, Fmt = ' ', Req = ' ', Rules = "", Dsc = "No longer used",  },
                    new DscRecField { RecTypeCode = "WPL", SeqNr = 5, Field = "Filler8", Start = 29, Size = 9, Fmt = 'L', Req = 'C', Rules = " ", Dsc = "No longer used",  },
                    new DscRecField { RecTypeCode = "WPL", SeqNr = 6, Field = "Writer IPI Name #", Start = 38, Size = 11, Fmt = 'L', Req = 'C', Rules = "1", Dsc = "The IPI Name # for the writer linked to the Publisher IPI Name #on this record.",  },
                    new DscRecField { RecTypeCode = "WPL", SeqNr = 7, Field = "Publisher  IPI Name #", Start = 49, Size = 11, Fmt = 'L', Req = 'C', Rules = "2", Dsc = "The IPI Name #for the publisher linked to the Writer IPI Name #on this record.",  },
                });

            modelBuilder
                .Entity<DscFieldColName>()
                .HasData(new DscFieldColName[]
                {
                    new DscFieldColName { FieldName = "Affiliation", ColName = "Aff",  },
                    new DscFieldColName { FieldName = "Alternate Title", ColName = "AltTtl",  },
                    new DscFieldColName { FieldName = "Archived ISWC", ColName = "ArchIswc",  },
                    new DscFieldColName { FieldName = "CD Identifier", ColName = "CdId",  },
                    new DscFieldColName { FieldName = "Composite Type", ColName = "CmpType",  },
                    new DscFieldColName { FieldName = "Condition Number", ColName = "CndNr",  },
                    new DscFieldColName { FieldName = "Conflict Note", ColName = "CflNote",  },
                    new DscFieldColName { FieldName = "Conflict Reason Code", ColName = "CflReasonCode",  },
                    new DscFieldColName { FieldName = "Contact ID", ColName = "CntrId",  },
                    new DscFieldColName { FieldName = "Contact Name", ColName = "CntrName",  },
                    new DscFieldColName { FieldName = "Copyright Date", ColName = "CprDate",  },
                    new DscFieldColName { FieldName = "Copyright Number", ColName = "CprNr",  },
                    new DscFieldColName { FieldName = "Creation Date", ColName = "CreDate",  },
                    new DscFieldColName { FieldName = "Creation Time", ColName = "CreTime",  },
                    new DscFieldColName { FieldName = "Creation Title", ColName = "CreTtl",  },
                    new DscFieldColName { FieldName = "Cut Number", ColName = "CutNr",  },
                    new DscFieldColName { FieldName = "Duration", ColName = "Dur",  },
                    new DscFieldColName { FieldName = "Entire Work Title", ColName = "EntireWrkTtl",  },
                    new DscFieldColName { FieldName = "Excerpt Type", ColName = "ExcType",  },
                    new DscFieldColName { FieldName = "Filler1", ColName = "Filler1",  },
                    new DscFieldColName { FieldName = "Filler2", ColName = "Filler2",  },
                    new DscFieldColName { FieldName = "Filler3", ColName = "Filler3",  },
                    new DscFieldColName { FieldName = "Filler4", ColName = "Filler4",  },
                    new DscFieldColName { FieldName = "Filler5", ColName = "Filler5",  },
                    new DscFieldColName { FieldName = "Filler6", ColName = "Filler6",  },
                    new DscFieldColName { FieldName = "Filler7", ColName = "Filler7",  },
                    new DscFieldColName { FieldName = "Filler8", ColName = "Filler8",  },
                    new DscFieldColName { FieldName = "First sending date to CIS-Net", ColName = "FstSendDateToCis",  },
                    new DscFieldColName { FieldName = "Instrument Code", ColName = "InstrCode",  },
                    new DscFieldColName { FieldName = "Instrumentation Description", ColName = "InstrDsc",  },
                    new DscFieldColName { FieldName = "Intended Purpose", ColName = "IntndPps",  },
                    new DscFieldColName { FieldName = "Interested Party #", ColName = "IpNr",  },
                    new DscFieldColName { FieldName = "IP First Name", ColName = "IpFstName",  },
                    new DscFieldColName { FieldName = "IP Name", ColName = "IpName",  },
                    new DscFieldColName { FieldName = "IP Role", ColName = "IpRole",  },
                    new DscFieldColName { FieldName = "IPI Name #", ColName = "IpNameNr",  },
                    new DscFieldColName { FieldName = "ISWC", ColName = "Iswc",  },
                    new DscFieldColName { FieldName = "ISWC of Component", ColName = "IswcComp",  },
                    new DscFieldColName { FieldName = "ISWC of Entire Work", ColName = "IswcWrk",  },
                    new DscFieldColName { FieldName = "ISWC of Original Work", ColName = "IswcOrigWrk",  },
                    new DscFieldColName { FieldName = "Language Code", ColName = "LngCode",  },
                    new DscFieldColName { FieldName = "Last sending date to CIS-Net", ColName = "LstSendDateToCis",  },
                    new DscFieldColName { FieldName = "Lyric Adaptation", ColName = "LyrAdapt",  },
                    new DscFieldColName { FieldName = "Message Level", ColName = "MsgLevel",  },
                    new DscFieldColName { FieldName = "Message Text", ColName = "MsgTxt",  },
                    new DscFieldColName { FieldName = "Message Type", ColName = "MsgType",  },
                    new DscFieldColName { FieldName = "Music Arrangement ", ColName = "MusicArr",  },
                    new DscFieldColName { FieldName = "Musical Work Distribution Category", ColName = "MwDistrCat",  },
                    new DscFieldColName { FieldName = "New Work Title", ColName = "NewWrkTtl",  },
                    new DscFieldColName { FieldName = "Number of Players", ColName = "NumOfPlayers",  },
                    new DscFieldColName { FieldName = "Number of Voices", ColName = "NumOfVoices",  },
                    new DscFieldColName { FieldName = "Original Group Number", ColName = "OrigGrpNr",  },
                    new DscFieldColName { FieldName = "Original Record Sequence ", ColName = "OrigRecSeq",  },
                    new DscFieldColName { FieldName = "Original Record Type", ColName = "OrigRecType",  },
                    new DscFieldColName { FieldName = "Original Transaction Sequence #", ColName = "OrigTransSeqNr",  },
                    new DscFieldColName { FieldName = "Original Transaction Type", ColName = "OrigTransType",  },
                    new DscFieldColName { FieldName = "Original Work Title", ColName = "OrigWrkTtl",  },
                    new DscFieldColName { FieldName = "Performing Artist First Name", ColName = "PerfArtistFstName",  },
                    new DscFieldColName { FieldName = "Performing Artist IPI Name #", ColName = "PerfArtistIpNameNr",  },
                    new DscFieldColName { FieldName = "Performing Artist Last Name", ColName = "PerfArtistLstName",  },
                    new DscFieldColName { FieldName = "Processing Date", ColName = "ProcDate",  },
                    new DscFieldColName { FieldName = "Production Title", ColName = "ProdTtl",  },
                    new DscFieldColName { FieldName = "Publisher  IPI Name #", ColName = "PubIpNameNr",  },
                    new DscFieldColName { FieldName = "Recipient Creation #", ColName = "RcpntCreNr",  },
                    new DscFieldColName { FieldName = "Record Sequence #", ColName = "RecSeqNr",  },
                    new DscFieldColName { FieldName = "Record Type", ColName = "RecType",  },
                    new DscFieldColName { FieldName = "Recorded Indicator", ColName = "RecInd",  },
                    new DscFieldColName { FieldName = "Right Type", ColName = "RightType",  },
                    new DscFieldColName { FieldName = "Shares", ColName = "Shares",  },
                    new DscFieldColName { FieldName = "Society Code", ColName = "SocCode",  },
                    new DscFieldColName { FieldName = "Society Work type", ColName = "SocWrkType",  },
                    new DscFieldColName { FieldName = "Source", ColName = "Src",  },
                    new DscFieldColName { FieldName = "Standard Instrumentation Type", ColName = "StdInstrType",  },
                    new DscFieldColName { FieldName = "Submitter Creation #", ColName = "SubmCreNr",  },
                    new DscFieldColName { FieldName = "Submitter Work #", ColName = "SubmWrkNr",  },
                    new DscFieldColName { FieldName = "Text Music Relationship", ColName = "TxtMusicRel",  },
                    new DscFieldColName { FieldName = "Title", ColName = "Ttl",  },
                    new DscFieldColName { FieldName = "Title Type", ColName = "TtlType",  },
                    new DscFieldColName { FieldName = "Transaction Sequence #", ColName = "TransSeqNr",  },
                    new DscFieldColName { FieldName = "Transaction Status", ColName = "TransStt",  },
                    new DscFieldColName { FieldName = "Type of Right", ColName = "RightType",  },
                    new DscFieldColName { FieldName = "Update date ", ColName = "UpdDate ",  },
                    new DscFieldColName { FieldName = "Version Type", ColName = "VerType",  },
                    new DscFieldColName { FieldName = "WI Code", ColName = "WicCode",  },
                    new DscFieldColName { FieldName = "WIC ", ColName = "Wic",  },
                    new DscFieldColName { FieldName = "WIC of Deleted Work", ColName = "WickDelWr",  },
                    new DscFieldColName { FieldName = "WIC of Newly Merged Work", ColName = "kMergedWrk",  },
                    new DscFieldColName { FieldName = "Work Title", ColName = "WrkTtl",  },
                    new DscFieldColName { FieldName = "Writer 1: First Name", ColName = "WrtFstName1",  },
                    new DscFieldColName { FieldName = "Writer 1: IPI Name #", ColName = "WrtIpNameNr1",  },
                    new DscFieldColName { FieldName = "Writer 1: Last Name", ColName = "WrtLstName1",  },
                    new DscFieldColName { FieldName = "Writer 2: First Name", ColName = "WrtFstName2",  },
                    new DscFieldColName { FieldName = "Writer 2: IPI Name #", ColName = "WrtIpNameNr2",  },
                    new DscFieldColName { FieldName = "Writer 2: Last Name", ColName = "WriterLstName2",  },
                    new DscFieldColName { FieldName = "Writer First Name", ColName = "WrtFstName",  },
                    new DscFieldColName { FieldName = "Writer IPI Name #", ColName = "WrtIpNameNr",  },
                    new DscFieldColName { FieldName = "Writer Last Name", ColName = "WrtLstName",  },
                });

            modelBuilder
                .Entity<DscFmtInfo>()
                .HasData(new DscFmtInfo[]
                {
                    new DscFmtInfo { Fmt = 'A', CsTypeName = "string", SqlTypeName = "varchar"                         },
                    new DscFmtInfo { Fmt = 'D', CsTypeName = "string", SqlTypeName = "varchar"                         },
                    new DscFmtInfo { Fmt = 'F', CsTypeName = "string", SqlTypeName = "varchar"                         },
                    new DscFmtInfo { Fmt = 'L', CsTypeName = "string", SqlTypeName = "varchar"                         },
                    new DscFmtInfo { Fmt = 'N', CsTypeName = "string", SqlTypeName = "varchar"                         },
                    new DscFmtInfo { Fmt = 'O', CsTypeName = "string", SqlTypeName = "varchar"                         },
                });
            }

    }
}
