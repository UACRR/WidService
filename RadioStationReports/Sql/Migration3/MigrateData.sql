select *
from Reports

drop table if exists #Candidates
select distinct t1.ReportId, t2.RegId
into #Candidates
from ReportLines t1
	join MediaService..RegisterItem t2 on 
			t1.LineNr	 = t2.regIItemId
		and t1.Name		 = t2.ItemName
		and t2.Performer = t2.Performer
select distinct ReportId from #Candidates order by ReportId

select t1.ReportId, t1.RegId, count(*)
from #Candidates t1
	join ReportLines t2 on t1.ReportId = t2.ReportId
group by t1.ReportId, t1.RegId
order by t1.ReportId

drop table if exists #Candidates1
; with Counts1 as (
	select t1.ReportId, t1.RegId, count(*) as cnt
	from #Candidates t1
		join MediaService..RegisterItem t2 on t1.RegId = t2.RegId
	group by t1.ReportId, t1.RegId
),
Counts2 as (
	select t1.ReportId, t1.RegId, count(*) as cnt
	from #Candidates t1
		join ReportLines t2 on t1.ReportId = t2.ReportId
	group by t1.ReportId, t1.RegId
)
select t1.ReportId, t1.RegId
into #Candidates1
from Counts1 t1
	join Counts2 t2 on
		t1.ReportId = t2.ReportId
		and t1.RegId = t2.RegId
		and t1.Cnt = t2.Cnt

select * from #Candidates1


drop table if exists #PartialMatch
select distinct t0.ReportId, t0.RegId
into #PartialMatch
from #Candidates t0
	join ReportLines t1 on t0.ReportId = t1.ReportId
	left join MediaService..RegisterItem t2 on 
			t1.LineNr	 = t2.regIItemId
		and t1.Name		 = t2.ItemName
		and t2.Performer = t2.Performer
where t2.RegId is null
select * from #PartialMatch order by ReportId

delete t1
from #Candidates t1
	join #PartialMatch t2 on t1.regId = t2.regId
		and t1.ReportId = t2.ReportId

select *
from #Candidates
order by ReportId

select *
from #Candidates1 t0
	join ReportLines t1 on t0.ReportId = t1.ReportId
	left join MediaService..RegisterItem t2 on
			t0.RegId = t2.RegId
		and t1.LineNr = t2.regIItemId
--where t1.ReportId = 28 and t2.RegId = 6075
where t2.RegId is null
order by LineNr


12	8270
17	3597
20	6002
21	6039
24	7221
27	5997
28	6046
28	6052
28	6075
33	6081
35	7164
35	7167
35	7170
36	7163
59	3733
65	7216
67	8280
81	7195
1097	3651
1097	3863
1097	6032
1097	8355
2101	7138
14	3730
17	3610
18	3515
19	3939
20	6047
21	6049
25	7162
26	6068
28	6001
34	7222
35	7151
35	7154
52	3814
54	3742
59	5976
66	7262
80	6110
89	3845
1095	7148
1097	1289
1097	3484
1097	11539
1104	1041
2103	8281
2136	8294
12	6036
20	6050
21	5995
24	6041
28	6045
28	6051
28	7166
35	6082
49	7220
50	7172
53	6018
63	3935
67	8281
69	3762
77	3928
82	7220
87	7175
89	3846
89	3933
90	3930
1097	3485
1097	11540
1103	1041
17	3608
20	6001
21	6038
21	6044
28	6002
31	3818
34	6077
35	6073
35	6076
35	7159
35	7165
36	7168
38	3854
41	3856
43	6070
48	7130
48	8306
52	11556
62	7157
62	7160
71	7218
72	7261
73	3894
78	7202
79	7256
12	5999
14	3731
15	5994
17	3606
20	6045
20	6051
20	7166
21	6042
25	6078
26	6011
26	6069
28	6037
28	8273
29	3894
31	6071
34	6079
35	7153
42	5993
49	7145
62	7156
78	7201
80	7194
89	3931
91	3929
1100	3934
1104	1042
2103	8280
13	6012
14	6010
16	5990
20	6046
20	6052
24	6008
28	6047
32	6081
36	6072
50	7171
52	1293
52	7147
83	8267
1097	1288
1097	8382
1100	3932
14	6009
17	3599
17	3622
20	6000
20	6003
20	6035
26	6053
28	6050
31	3819
35	6074
35	7169
40	3855
48	7129
48	8305
52	3631
72	7263
81	6111
82	7145
1097	6031
1097	6034
1097	8354
1102	5998
1103	1042
16	6013
17	3601
17	3604
19	3940
20	6037
20	6075
20	8273
21	6040
21	6043
25	8271
26	6048
28	6000
28	6003
28	6035
31	3820
37	3853
39	3857
52	11557
62	7155
62	7161
71	7217
72	7265
72	7268
84	7257
1097	3594
1097	3864
1097	6033
1097	8353
1101	5992