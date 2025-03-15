using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public partial class DdexReport
    {
        public void MergeMusicWorks()
        {
            const int incr = 10000;
            Logger.WriteLine("Додавання нових музичних творів для ідентифікації");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterString(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = $@"select isnull(max(blockId), 0) from [DdexIdentificationBacklog] where {filter}";
                        int maxBlock = (int)cmd.ExecuteScalar();
                        cmd.CommandText = $@"select isnull(max(blockId), 0) + 1 from [DdexIdentificationBacklog] where {filter} and ExcStatus = 1";
                        int firstBlock = (int)cmd.ExecuteScalar();
                        int lastBlock = firstBlock + incr;
                        cmd.Parameters.AddWithValue("@firstBlock", firstBlock);
                        cmd.Parameters.AddWithValue("@lastBlock", lastBlock);
                        cmd.CommandText = $@"
                            insert IdentMw  (ResourceTitle, Title,      ComposerAuthor,    DisplayArtistName,    ISWC,    [status])
                            select distinct  t1.asTitle,    t1.mwTitle, t1.composerauthor, t1.DisplayArtistName, t1.ISWC, 0
                            from DdexIdentificationBacklog t1
                                left join IdentMw t2 on 
                                            t2.ResourceTitle = t1.AsTitle 
                                        and t2.Title = t1.mwTitle 
                                        and t2.ComposerAuthor = t1.ComposerAuthor
                                        and t2.DisplayArtistName = t1.DisplayArtistname
                                        and t2.ISWC = t1.ISWC
                            where 
                                    {filter} 
                                and blockid >= @firstBlock 
                                and blockId < @lastBlock 
                                and t2.Title is null
                            
                            update [DdexIdentificationBacklog] 
                            set ExcStatus = 1 
                            where 
                                    {filter} 
                                and blockid >= @firstBlock 
                                and blockId < @lastBlock
                        ";
                        while (firstBlock <= maxBlock)
                        {
                            cmd.ExecuteNonQuery();
                            int processedBlocks = lastBlock - 1 < maxBlock ? lastBlock - 1 : maxBlock;
                            Logger.WriteLine($"Оброблено {processedBlocks} блоків із {maxBlock}");
                            firstBlock = lastBlock;
                            lastBlock = firstBlock + incr;
                            cmd.Parameters["@firstBlock"].Value = firstBlock;
                            cmd.Parameters["@lastBlock"].Value = lastBlock;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Додавання нових музичних творів для ідентифікації завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Додавання нових музичних творів для ідентифікації завершено");
        }

        public void CreateIdentBacklog()
        {
            Logger.WriteLine("Створення черги для обробки інформації розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterString(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = $@"select count(*) from DdexIdentificationBacklog where {filter}";
                        int totalRowCount = (int)cmd.ExecuteScalar();
                        cmd.CommandText = $@"select count(*) from IdentBacklog where {filter}";
                        int insertedRowCount = (int)cmd.ExecuteScalar();
                        cmd.CommandText = $@"select isnull(max(blockId), 0) from [DdexIdentificationBacklog] where {filter}";
                        int maxBlock = (int)cmd.ExecuteScalar();
                        cmd.CommandText = $@"select isnull(max(blockId), 0) + 1 from IdentBacklog where {filter}";
                        int firstBlock = (int)cmd.ExecuteScalar();
                        int lastBlock = firstBlock + 10000;
                        cmd.Parameters.AddWithValue("@firstBlock", firstBlock);
                        cmd.Parameters.AddWithValue("@lastBlock", lastBlock);

                        cmd.CommandText = $@"
                            insert IdentBacklog (DdexReportId, BlockId, SalesTransactionId, DspResourceId, DspReleaseId, ContentCategory
                                                                , NetRevenue, Usages, ValidityPeriodStart, ValidityPeriodEnd, rateTotalPER, rateTotalMEC, mwId)
                            select DdexReportId, BlockId, SalesTransactionId, DspResourceId, DspReleaseId, ContentCategory
                                    , NetRevenue, Usages, ValidityPeriodStart, ValidityPeriodEnd, 0, 0, t2.id
                            from DdexIdentificationBacklog t1 
                                left join IdentMw t2 on 
                                    t2.ResourceTitle = t1.AsTitle 
                                    and t2.Title = t1.mwTitle 
                                    and t2.ComposerAuthor = t1.ComposerAuthor
                                    and t2.DisplayArtistName = t1.DisplayArtistname
                                    and t2.ISWC = t1.ISWC
                            where {filter} and blockid >= @firstBlock and blockId < @lastBlock
                            select @@ROWCOUNT
                        ";
                        while (firstBlock <= maxBlock)
                        {
                            int rowCount = cmd.ExecuteNonQuery();
                            //if (rowCount == 0)
                                //break;
                            insertedRowCount += rowCount;
                            Logger.WriteLine($"Додано {insertedRowCount} записів із {totalRowCount}");

                            firstBlock = lastBlock;
                            lastBlock = firstBlock + 10000;
                            cmd.Parameters["@firstBlock"].Value = firstBlock;
                            cmd.Parameters["@lastBlock"].Value = lastBlock;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Створення черги для обробки інформації завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Створення черги для обробки інформації завершено");
        }

        public void CreateIdentBacklogToMwLink()
        {
            Logger.WriteLine("Встановлення відповідності елементів черги з музичними творами розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterString(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = $@"delete from IdentReportMwRecords where {filter}
                            insert IdentReportMwRecords(DdexReportId, mwId)
                            select distinct DdexReportId, mwId
                            from IdentBacklog
                            where {filter}";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Встановлення відповідності елементів черги з музичними творами завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Встановлення відповідності елементів черги з музичними творами завершено");
        }

        public void CreatePseudoNetRevenue()
        {
            Logger.WriteLine("Розрахунок оціночного прибутку від використання музичних творів розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = @"declare @fileType varchar(100) = (select FileType from DdexReport where Id = @ddexReportId);
                            if @fileType in ('Subscription-Music', 'Subscription-Premium')
                            begin
                                declare @TotalRevenue float = 
                                    (select sum(netrevenue) 
                                    from DdexRecordSY_04_01 
                                    where ddexReportId = @ddexReportId 
                                    and SubscriberType = 'all'
                                    )
                                declare @MusicPlusGEMusicViews bigint = 
                                    (select sum(TotalUsages) 
                                    from DdexRecordSY_05_02 
                                    where ddexReportId = @ddexReportId 
                                    and ContentCategory in ('Music', 'GEMusic'))

                                declare @ConstantGrossRevenueValue float = @TotalRevenue / @MusicPlusGEMusicViews;

                                update IdentBacklog
                                set NetRevenue = @ConstantGrossRevenueValue * Usages
                                where ddexReportId = @ddexReportId
                            end";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Розрахунок оціночного прибутку від використання музичних творів завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Розрахунок оціночного прибутку від використання музичних творів завершено");
        }

        public void CalcNetRevenuePerMusicWork()
        {
            Logger.WriteLine("Рознесення загального прибутку на окремі музичні твори розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterStringShort(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        /*
                        cmd.CommandText = @";with sums as (
                            select t2.mwId, sum(t1.NetRevenue) NetRevenue, count(*) IdentBacklogRecCnt 
                            from IdentBacklog t1 
                                inner join IdentReportMwRecords t2 on t2.mwId = t1.mwId
                            where t1.ddexReportId = @ddexReportId
                            group by t2.mwId
                        )
                        update t2
                        set t2.NetRevenue =  t1.NetRevenue, t2.IdentBacklogRecCnt = t1.IdentBacklogRecCnt
                        from sums t1 
                            inner join IdentReportMwRecords t2 on t2.mwId = t1.mwId
                        where t2.ddexReportId = @ddexReportId";
                        */
                        cmd.CommandText = $@"
                            drop table if exists #sum

                            select
                                  t2.ddexReportId
                                , t2.mwId
                                , sum(t1.NetRevenue) NetRevenue
                                , count(*) IdentBacklogRecCnt 
                            into #sum
                            from IdentBacklog t1 
                                inner join IdentReportMwRecords t2 on 
                                            t2.ddexReportId = t1.ddexReportId 
                                        and t2.mwId = t1.mwId
                            where t1.ddexReportId {filter}
                            group by t2.ddexReportId, t2.mwId

                            update t2
                            set 
                                  t2.NetRevenue =  t1.NetRevenue
                                , t2.IdentBacklogRecCnt = t1.IdentBacklogRecCnt
                            from #sum t1 
                                inner join IdentReportMwRecords t2 on 
                                            t2.ddexReportId = t1.ddexReportId 
                                        and t2.mwId = t1.mwId
                            where t2.ddexReportId {filter}

                            drop table if exists #sum
                        ";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Рознесення загального прибутку на окремі музичні твори завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Рознесення загального прибутку на окремі музичні твори завершено");
        }

        public void AutoIdentByIswc()
        {
            Logger.WriteLine("Ідентифікація музичних творів за кодом ISWC та Автором/Виконевцем розпочата");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterStringShort(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = $@"update t1
                            set t1.Wic = t2.Wic, t1.status = 2
                            from Ddex..IdentReportMwRecords t3
                                join Ddex..IdentMW t1 on t3.mwId = t1.Id
                                join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
                            where t1.status <> 2
                                and trim(isnull(t1.Iswc, '')) <> ''
                                and t3.ddexReportId {filter}";
                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spIdentByNameAndPerformer";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Ідентифікація музичних творів за кодом ISWC та Автором/Виконевцем завершилась з помилками");
                throw;
            }

            Logger.WriteLine("Ідентифікація музичних творів за кодом ISWC та Автором/Виконевцем завершена");
        }

        public void CalcMwPriorities()
        {
            Logger.WriteLine("Сортування музичних творів згідно очікуваного прибутку розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterStringShort(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText =$@"update IdentReportMwRecords
                            set PriorityIndex = null
                            where ddexReportId {filter}

                            drop table if exists #tmp;
                            select t1.ddexReportId
                                , t1.mwId
                                , row_number() over(order by t1.NetRevenue desc) as rn
                            into #tmp
                            from IdentReportMwRecords t1
                                join IdentMW t2 on t1.mwId = t2.Id
                            where 
                                    isnull(t2.Wic, 0) = 0 
                                and isnull(t2.ObjId, 0) = 0 
                                and t1.ddexReportId {filter}
 
                            update t2
                            set t2.PriorityIndex = t1.rn 
                            from #tmp t1
                                join IdentReportMwRecords t2 on 
                                        t1.DdexReportId = t2.ddexReportId 
                                    and t1.mwId = t2.mwId

                            drop table if exists #tmp;";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Сортування музичних творів згідно очікуваного прибутку завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Сортування музичних творів згідно очікуваного прибутку завершено");
        }

        public void CalcBasicReportStatistics()
        {
            Logger.WriteLine("Розрахунок головної статистичної інформації для звіту розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterStringShort(cmd, ddexReportId);
                        var isMultiFile = IsMultiFile(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        if(isMultiFile)
                        {
                            cmd.CommandText = $@";with sums as (
                                    select 
                                          @ddexReportId DdexReportId
                                        , sum(NetRevenue) NetRevenue
                                        , count(*) count
                                    from IdentBacklog
                                    where ddexReportId {filter}
                                )
                                update t1 
                                set t1.NetRevenue = t2.NetRevenue,
                                    t1.SalesTransCnt = t2.count
                                from DdexReport t1
                                    join sums t2 on t1.Id = t2.DdexReportId
                                where t1.Id = @ddexReportId";
                        }
                        else
                        {
                                cmd.CommandText = $@";with sums as (
                                    select ddexReportId, sum(NetRevenue) NetRevenue, Count(*) count
                                    from IdentBacklog
                                    where ddexReportId {filter}
                                    group by ddexReportId
                                )
                                update t1 
                                set t1.NetRevenue = t2.NetRevenue,
                                    t1.SalesTransCnt = t2.count
                                from DdexReport t1
                                    join sums t2 on t1.Id = t2.DdexReportId
                                where t1.Id {filter}";
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Розрахунок головної статистичної інформації для звіту завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Розрахунок головної статистичної інформації для звіту завершено");
        }

        public void CalcDetailedReportStatistics()
        {
            Logger.WriteLine("Розрахунок додаткової статистичної інформації для звіту розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterStringShort(cmd, ddexReportId);
                        var isMultiFile = IsMultiFile(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        if(isMultiFile)
                        {
                            cmd.CommandText = $@";with stat as (
                                select 
                                      @ddexReportId ddexReportId
                                    , count(*) MwCnt
                                    , sum(case when status = 2 then 0 else 1 end) MwCntUnmatched
                                    , sum(t2.NetRevenue) NetRevenue
                                    , sum(case when status = 2 then 0 else t2.NetRevenue end) NetRevenueUnmatched
                                    , sum(case when ISWC <> '' then 1 else 0 end) MwCntIswcTotal
                                    , sum(case when ISWC <> '' then t2.NetRevenue else 0 end) MwNetRevenueIswcTotal
                                    , sum(case when ISWC <> '' and status = 2 then 1 else 0 end) MwCntIswcMatched
                                    , sum(case when ISWC <> '' and status = 2  then t2.NetRevenue else 0 end) MwNetRevenueIswcMatched
                                from IdentMw t1 
                                    join IdentReportMwRecords t2 on t1.Id = t2.mwId
                                where t2.ddexReportId {filter}
                                )
                                update t1
                                set t1.MwCnt = t2.MwCnt
                                    , t1.MwCntUnmatched = t2.MwCntUnmatched
                                    , t1.NetRevenue = t2.NetRevenue
                                    , t1.NetRevenueUnmatched = t2.NetRevenueUnmatched
                                    , t1.MwCntIswcTotal = t2.MwCntIswcTotal
                                    , t1.MwNetRevenueIswcTotal = t2.MwNetRevenueIswcTotal
                                    , t1.MwCntIswcMatched = t2.MwCntIswcMatched
                                    , t1.MwNetRevenueIswcMatched = t2.MwNetRevenueIswcMatched
                                from stat t2 
                                    join ddexReport t1 on t1.id = t2.ddexReportId";
                        }
                        else
                        {
                                cmd.CommandText = $@";with stat as (
                                select 
                                      @ddexReportId ddexReportId
                                    , count(*) MwCnt
                                    , sum(case when status = 2 then 0 else 1 end) MwCntUnmatched
                                    , sum(t2.NetRevenue) NetRevenue
                                    , sum(case when status = 2 then 0 else t2.NetRevenue end) NetRevenueUnmatched
                                    , sum(case when ISWC <> '' then 1 else 0 end) MwCntIswcTotal
                                    , sum(case when ISWC <> '' then t2.NetRevenue else 0 end) MwNetRevenueIswcTotal
                                    , sum(case when ISWC <> '' and status = 2 then 1 else 0 end) MwCntIswcMatched
                                    , sum(case when ISWC <> '' and status = 2  then t2.NetRevenue else 0 end) MwNetRevenueIswcMatched
                                from IdentMw t1 
                                    join IdentReportMwRecords t2 on t1.Id = t2.mwId
                                where t2.ddexReportId {filter}
                                )
                                update t1
                                set t1.MwCnt = t2.MwCnt
                                    , t1.MwCntUnmatched = t2.MwCntUnmatched
                                    , t1.NetRevenue = t2.NetRevenue
                                    , t1.NetRevenueUnmatched = t2.NetRevenueUnmatched
                                    , t1.MwCntIswcTotal = t2.MwCntIswcTotal
                                    , t1.MwNetRevenueIswcTotal = t2.MwNetRevenueIswcTotal
                                    , t1.MwCntIswcMatched = t2.MwCntIswcMatched
                                    , t1.MwNetRevenueIswcMatched = t2.MwNetRevenueIswcMatched
                                from ddexReport t1 
                                    join stat t2 on t1.id = t2.ddexReportId";
                        }
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Розрахунок додаткової статистичної інформації для звіту завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Розрахунок додаткової статистичної інформації для звіту завершено");
        }

        public void CalcPriorityBlocksStatistics()
        {
            Logger.WriteLine("Розрахунок статистичної інформації для блоків музичних творів розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        var filter = GetFilterStringShort(cmd, ddexReportId);

                        cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = $@"delete from DdexNetRevenueDistr where DdexReportId {filter}

                                declare @netRevenue decimal(20,6);
                                declare @blockNetRevenue decimal(20,6) = 0;
                                declare @netRevenueAccr decimal(20,6) = 0;
                                declare @netRevenueTotal decimal(20,6);
                                declare @recCntTotal int;
                                declare @margin decimal(20, 6);
                                declare @recCount int = 0;
                                declare @blockRecCount int = 0;
                                declare @blockStartRec int;

                                select @netRevenueTotal = sum(NetRevenueUnmatched)
                                    , @recCntTotal = sum(MwCntUnmatched)
                                from ddexReport 
                                where id {filter}

                                set @margin = @netRevenueTotal * 0.95 

                                DECLARE cMwRecors CURSOR 
                                LOCAL STATIC READ_ONLY FORWARD_ONLY
                                FOR     
                                select NetRevenue
                                from IdentReportMwRecords
                                where ddexReportId {filter} and PriorityIndex is not null
                                order by PriorityIndex
 
                                OPEN cMwRecors    
  
                                FETCH NEXT FROM cMwRecors INTO @netRevenue;
                                set @blockNetRevenue = 0;
                                set @netRevenueAccr = 0;
                                set @recCount = 0;
                                set @blockRecCount = 0;
                                set @blockStartRec = 1;
  
                                WHILE @@FETCH_STATUS = 0 and @netRevenueAccr < @margin
                                BEGIN    
                                    set @blockNetRevenue = @blockNetRevenue + @netRevenue;
                                    set @netRevenueAccr = @netRevenueAccr + @netRevenue;
                                    set @recCount = @recCount + 1;
                                    set @blockRecCount = @blockRecCount + 1;
                                    if @blockRecCount = 1000
                                    begin
                                        insert DdexNetRevenueDistr
                                        select @ddexReportId, @blockStartRec, @recCount, @blockNetRevenue, @netRevenueAccr, 0, 0

                                        set @blockNetRevenue = 0;
                                        set @blockRecCount = 0;
                                        set @blockStartRec = @recCount + 1;
                                    end
                                    FETCH NEXT FROM cMwRecors INTO @netRevenue;

                                END     
                                CLOSE cMwRecors;    
                                DEALLOCATE cMwRecors;  
                                -- cursor

                                insert DdexNetRevenueDistr
                                select @ddexReportId, @blockStartRec, @recCntTotal, @netRevenueTotal - @netRevenueAccr, @netRevenueTotal, 0, 0

                                if @netRevenueTotal <> 0
                                    update DdexNetRevenueDistr
                                        set share = cast(netRevenue / @netRevenueTotal * 100 as decimal(10, 2))
                                        , shareAccr = cast(netRevenueAccr / @netRevenueTotal * 100 as decimal(10, 2)) 
                                    from DdexNetRevenueDistr
                                    where ddexReportId {filter}
                                else
                                    update DdexNetRevenueDistr
                                        set share = cast(0 as decimal(10, 2))
                                        , shareAccr = cast(0 as decimal(10, 2)) 
                                    from DdexNetRevenueDistr
                                    where ddexReportId {filter}";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Розрахунок статистичної інформації для блоків музичних творів завершено з помилками");
                throw;
            }

            Logger.WriteLine("Розрахунок статистичної інформації для блоків музичних творів завершено");
        }
    }
}
