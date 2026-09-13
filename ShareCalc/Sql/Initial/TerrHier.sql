UKRAINE 0804
CIS                 	2118
EASTERN EUROPE      	2119
EUROPE              	2120
EUROPEAN CONT.      	2122
WORLD               	2136

select *
from SocIpi..DicHna
where TisanCh = 'EUROPEAN CONT.'

UKRAINE
	CIS               
	EASTERN EUROPE 
		EUROPE            
		EUROPEAN CONT.  
	EUROPE            
	EUROPEAN CONT. 
		EUROPE     
	WORLD

1. WORLD
  1.1.CIS               
  1.2. EUROPE            
    1.2.1 EASTERN EUROPE
    1.2.2 EUROPEAN CONT.  
  1.3 UKRAINE
	


