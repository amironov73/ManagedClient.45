/*IBIS_KL_TIT
1200 8 MHL,'/K=/'(v200^a,|%|d200/) 
12251 8 MHL,'/K=/'(v225^a,|%|d225/) 
12252 8 MHL,'/K=/'(v225^i,|%|d225/) 
12253 8 MHL,'/K=/'(v225^l,|%|d225/) 
1330 8 MHL,'/K=/'(v330^c,|%|d330/) 
1430 8 MHL,'/K=/'(v430^a,|%|d430/) 
1451 8 MHL,'/K=/'(v451^c,|%|d451/) 
1452 8 MHL,'/K=/'(v452^c,|%|d452/) 
1454 8 MHL,'/K=/'(v454^a,|%|d454/) 
1461 8 MHL,'/K=/'(v46^l,|%|d46/) 
1462 8 MHL,'/K=/'(v46^a,|%|d46/) 
1463 8 MHL,'/K=/'(v46^c,|%|d46/) 
1464 8 MHL,'/K=/'(v46^i,|%|d46/) 
1465 8 MHL,'/K=/'(v46^m,|%|d46/) 
14611 8 MHL,'/K=/'(v461^a,|%|d461/) 
14612 8 MHL,'/K=/'(v461^c,|%|d461/) 
14631 8 MHL,'/K=/'(v463^c,|%|d463/) 
1470 8 MHL,'/K=/'(v470^c,|%|d470/) 
1481 8 MHL,'/K=/'(v481^c,|%|d481/) 
1488 8 MHL,'/K=/'(v488^c,|%|d488/)
1510 8 MHL,'/K=/'(v510^d,|%|d510/) 
1517 8 MHL,'/K=/'(v517^a,|%|d517/) 
1541 8 MHL,'/K=/'(v541,|%|d541/)
1600 8 MHL,'/K=/'(v600^z|%|/)
1601 8 MHL,'/K=/'(v601^z|%|/)
1922 8 MHL,'/K=/'(v922^c,|%|d922/) 
19231 8 MHL,'/K=/'(v923^i,|%|d923/) 
19232 8 MHL,'/K=/'(v923^l,|%|d923/) 
19233 8 MHL,'/K=/'(v923^n,|%|d923/) 
1924 8 MHL,'/K=/'(v924,|%|d924/) 
19251 8 MHL,'/K=/'(v925^a,|%|d925/) 
19252 8 MHL,'/K=/'(v925^b,|%|d925/) 
19253 8 MHL,'/K=/'(v925^c,|%|d925/) 
/*IBIS_DUBL
999 0 if p(v200^a)and a(v981)and a(v463)and (not(v920:'spec'))then'!'v110^b,v11^a,if v210^d.1='['then else v210^d*2.2fi,v700^a.9,&unifor('B'v710^a" ",v200^a),if v920='J'then" "v923^h,if a(v923^h) then" "v923^i fi," "v923^k,if a(v923^k) then" "v923^l fi," "v923^m,if a(v923^m) then" "v923^n fi fi,if v920='J'then else (if p(v925) then &unifor(|G1#|v925^v) fi),(if val(v923^h)>0 then &unifor('G1#'v923^h) else v923^h fi,if val(v923^k)>0 then &unifor('G1#'v923^k) else v923^k fi) fi,v215^a fi 
999 0 if p(v200^a)and p(v981)then(if p(v981^a) then'!'v981^d*2.2,v981^n,&unifor('B'v981^a' '&unifor('Av200^a#1')) fi/)fi 
999 0 if p(v200^a)and a(v981)and p(v463)then (if p(v463^c)then'!'v463^j*2.2,&unifor('Av700^a.9#1'),&unifor('B'&unifor('Av710^a#1'),if &unifor('Av710^a#1')<>''then' 'fi,&unifor('Av200^a#1'),' 'v463^c),v463^v,v463^h,v463^k,if s(v463^v,v463^h,v463^k)='' then v463^s fi fi/) fi 
999 0 if v920:'spec'then'!'if v210^d.1='['then else v210^d*2.2 fi,if a(v210^d) then if v461^h.1='['then else v461^h*2.2 fi fi,&unifor('B'v461^c,if v461^u:'1'then' 'if v961^z<>'' then (if p(v961^z) then v961^a.9 fi) else v461^x.9 fi fi,if s(v200^v,v925)='' then" "v200^a fi),&unifor("G1#"v200^v),(if p(v925) then &unifor(|G1#|v925^v) fi),(if val(v923^h)>0 then &unifor('G1#'v923^h) else v923^h fi,if val(v923^k)>0 then &unifor('G1#'v923^k) else v923^k fi),v215^a fi 
999 0 if p(v225^v) then '!'if v210^d.1='['then else v210^d*2.2fi,v10^a,&unifor('B',&unifor('Av225^a#1')),&unifor('G1#'&unifor('Av225^v#1')),v215^a fi 
/*IBIS_TIT
200 0 MHL,if p(v461) and v200^u:'1'then else if p(v200^a) then'T=',&unifor("9"v200^a,(|. |v923^h,|.|v923^i,|. |v923^k,|.|v923^l,|. |v923^m,|.|v923^n)) fi,if v200^u:'1' then "/"v200^f fi fi 
200 0 MHL,if s(v982^0,v982^9)<>'' then if v200^a:&unifor('Av982^9#1') or v200^u:'1'then else 'T=',&unifor('Av982^0#1')," "d982^0,&unifor('Av982^9#1')," "d982^9 &unifor("9"v200^a,(|. |v923^h,|.|v923^i,|. |v923^k,|.|v923^l,|. |v923^m,|.|v923^n)) fi fi / 
200 0 MHL,if v920='J'then if p(v200^a) then'TJ=',&unifor("9"v200^a,". "v923^h,"."v923^i,". "v923^k,"."v923^l,". "v923^m,"."v923^n) fi fi  
200 0 MHL,if v920='J'then if p(v200^l) and p(v923)then 'TJ=',&unifor("9"v200^l,". "v923^h,"."v923^i,". "v923^k,"."v923^l,". "v923^m,"."v923^n) fi fi 
510 0 MHL,(if p(v510) then if v920='J'then |TJ=|d510^d else|T=|d510^d fi,&unifor(|9|v510^d) fi,|%|d510/) 
922 0 MHL,(if p(v922) then if p(v922^u)and f(val(v922^u),0,0)=v922^u then else |T=|d922^c,&unifor(|9|v922^c) fi,fi,|%|d922/) 
9227 0 MHL,(if p(v922) then |T=|d922^d,&unifor(|9|v922^d) fi,|%|d922/) 
9228 0 MHL,(if p(v922) then |T=|d922^p,&unifor(|9|v922^p) fi,|%|d922/) 
9229 0 MHL,(if p(v922) then |T=|d922^r,&unifor(|9|v922^r) fi,|%|d922/) 
9251 0 MHL,if p(v925^a) then &uf('+7W46#'),&uf('+7W46#'(|. |v46^h,if p(v46^i) then|, |v46^i else |. |v46^i fi,|. |v46^k,if p(v46^k) then|, |v46^m else |. |v46^m fi)),(if p(v925^a) then if v925^u:'1'and &unifor('Av461^c#1')<>''then'T=',&uf('9'&unifor('Av461^c#1'),&uf('Ag46#1'),if &uf('Av461^u#1'):'1'then if s(&uf('Av461^x#1'),&uf('Av461^b#1'))<>''then'/'&uf('Av461^x#1'),&uf('Av461^b#1') fi fi,|;|v925^v,|:|v925^a) else /'T='&uf('9'v925^a) fi fi,|%|d925/)/fi 
9252 0 MHL,(if p(v925^b) then if v925^u:'1'and &uf('Av461^c#1')<>''then'T=',&uf('9'&uf('Av461^c#1'),&uf('Ag46#1'),if &uf('Av461^u#1'):'1'then if s(&uf('Av461^x#1'),&uf('Av461^b#1'))<>''then'/'&uf('Av461^x#1'),&uf('Av461^b#1') fi fi,|;|v925^v,|:|v925^b) else /'T='&uf('9'v925^b) fi fi,|%|d925/)/ 
9253 0 MHL,(if p(v925^c) then if v925^u:'1'and &uf('Av461^c#1')<>''then'T=',&uf('9'&unifor('Av461^c#1'),&uf('Ag46#1'),if &uf('Av461^u#1'):'1'then if s(&uf('Av461^x#1'),&uf('Av461^b#1'))<>''then'/'&uf('Av461^x#1'),&uf('Av461^b#1') fi fi,|;|v925^v,|:|v925^c) else /'T='&uf('9'v925^c) fi fi,|%|d925/)/ 
925 0 MHL, (if p(v925)   then if a(v925^u) and &unifor('Av461^c#1')<>''then'T=',&unifor('9'&unifor('Av461^c#1'),if &unifor('Av461^u#1'):'1'then if s(&unifor('Av461^x#1'),&unifor('Av461^b#1'))<>''then'/'&unifor('Av461^x#1'),&unifor('Av461^b#1') fi fi,|;|v925^v) fi fi,|%|d925/) 
470 0 MHL,(if p(v470^c) then'T=',&unifor(|9|v470^c,| (|v470^0|)|) fi,|%|d470/) 
923 0 MHL,(if p(v923^i) then if v923^u:'1'then else 'T=',&unifor(|9|v923^i,|. |v923^l,|. |v923^n) fi fi,|%|d923/) 
923 0 MHL,if v920='J'then "TJ="d923^i,&unifor("9"v923^i)/"TJ="d923^l,&unifor("9"v923^l)/"TJ="d923^n,&unifor("9"v923^n) fi 
461 0 MHL,if p(v461^c) then'TMN=',&unifor('9'v461^c,(|. |v46^h,if p(v46^i) then|, |v46^i else |. |v46^i fi,|. |v46^k,if p(v46^k) then|, |v46^m else |. |v46^m fi),if v461^u:'1'then|/|v461^x,|/|v461^b fi) fi 
461 0 MHL,if p(v461^c) then'T=',  &unifor('9'v461^c,(|. |v46^h,if p(v46^i) then|, |v46^i else |. |v46^i fi,|. |v46^k,if p(v46^k) then|, |v46^m else |. |v46^m fi),if v461^u:'1'then|/|v461^x,|/|v461^b fi," ; "v200^v,if v200^u:'1'then":"d200^v,"."n200^v,v200^a,(|. |v923^h,|.|v923^i,|. |v923^k,|.|v923^l,|. |v923^m,|.|v923^n) fi) fi 
4611 0 MHL,(if p(v461^a) then|T=|d461^a,&unifor(|9|v461^a) fi,|%|d461/) 
463 0 MHL,(if p(v463^c) then'T=',&unifor(|9|v463^c,|/ |v963^b,| (���. ��.)|d463^c) fi,|%|d463/) 
463 0 MHL,(if p(v463^c) then 'TI=',&unifor(|9|v463^c,|/ |v963^b),|,|v463^j,| |v463^v,| |v463^h,| |v463^k fi,|%|d463/) 
423 0 MHL,if v920='J'then (if p(v423) then|T=|d423^a,&unifor(|9|v423^a),|. |d423^s,v423^v| |,&unifor(|9|v423^s) fi,|%|d423/)fi 
423 0 MHL,if v920='J'then (|TJ=|d423^a,&unifor(|9|v423^a),|. |d423^s,v423^v| |,&unifor(|9|v423^s),|%|d423/)fi 
423 0 mhl,if v920='J'then (if p(v423^s) then |T=|d423^s,&unifor(|9|v423^s) fi,|%|d423/)fi 
423 0 mhl,if v920='J'then (|TS=|d423^s,&unifor(|9|v423^s),|%|d423/)fi 
330 0 MHL,(if p(v330) then if p(v330^u) and f(val(v330^u),0,0)=v330^u then else |T=|d330^c,&unifor(|9|v330^c) fi fi,|%|d330/) 
3307 0 MHL,(if p(v330) then|T=|d330^d,&unifor(|9|v330^d) fi,|%|d330/) 
430 0 MHL,(if p(v430) then|T=|d430^a,&unifor(|9|v430^a) fi,|%|d430/) 
430 0 MHL,if v920='J'then(|TJ=|d430^a,&unifor(|9|v430^a),|%|d430/)fi 
454 0 MHL,(if p(v454) then|T=|d454^a,&unifor(|9|v454^a,|/|v454^b) fi,|%|d454) 
481 0 MHL,(if p(v481^c) then if v481^u:'1'then else |T=|d481^c,&unifor(|9|v481^c),if a(v481^z) then |;|v481^v fi fi fi,|%|d481/)
481 0 MHL,if s(v481^z)<>''then &uf('+7W46#'),&uf('+7W46#'(|. |v46^h,if p(v46^i) then|, |v46^i else |. |v46^i fi,|. |v46^k,if p(v46^k) then|, |v46^m else |. |v46^m fi)),(if p(v481^z) then'T=',&unifor('9'&unifor('Av461^c#1'),&uf('Ag46#1'),if &unifor('Av461^u#1'):'1'then if s(&unifor('Av461^x#1'),&unifor('Av461^b#1'))<>''then'/'&unifor('Av461^x#1'),&unifor('Av461^b#1') fi fi,|;|v481^v,if v481^u:'1'then|:|v481^c fi) fi,|%|d481/) fi 
488 0 MHL,(if s(v488^c,v488^z)<>'' then |T=|d488,&uf(|9|d488,if v488^c<>''then if v488^u:'1'then v488^z, |;|v488^v |:|d488^c else v488^c,fi,|. |v488^r,|.|v488^s,|. |v488^k,|.|v488^l,else v488^z, |;|v488^v fi ) fi,|%|d488/),
541 0 MHL,if p(v541) then"T="d541,&unifor("9"v541) fi 
541 0 MHL,if v920='J'then"TJ="d541,&unifor("9"v541)fi 
517 0 MHL,(if p(v517) then|T=|d517^a,&unifor(|9|v517^a) fi,|%|d517/) 
225 0 MHL,(if p(v225^a) then'T=',&unifor(|9|v225^a,|/|v225^f) fi,|%|d225/) 
225 0 MHL,(if p(v225^a) then'TS=',&unifor(|9|v225^a,|/|v225^f) fi,|%|d225/) 
963 0 MHL,(if p(v963^a) then'TS=',&unifor(|9|v963^a,|/|v963^o) fi,|%|d963/) 
4601 0 MHL,(if p(v46^a) then|T=|d46^a,&unifor(|9|v46^a,|/|v46^f) fi,|%|d46/)/ 
4602 0 MHL,(if p(v46^l) then|T=|d46^l,&unifor(|9|v46^l) fi,|%|d46/) 
4603 0 MHL,(if p(v46^c) then|T=|d46^c,&unifor(|9|v46^c) fi,|%|d46/) 
46 0 MHL,(if p(v46^a) then|TS=|d46^a,&unifor(|9|v46^a,|/|v46^f) fi,|%|d46/)/ 
200 0 &uf('+960.100#',if v920='J' then else if s(v200^A,v461^C)<>'' then 'TV=',v461^c,". "d461,v200^v,if p(v200^v) then" : "v200^a else v200^a fi fi fi),' - ',v903
/*IBIS_AUT
7001 0 MHL,"A="v700^a," "v700^d,", "v700^g,if a(v700^g) then|, |d700^b,if v700^b:'. 'or (not(v700^b:'.')) then v700^b else &unifor('G0.'v700^b),'. '&unifor('G2.'v700^b) fi fi,,if s(v700^1,v700^c,v700^f)<>''then' (',v700^1,if s(v700^1)<>''then"; "d700^c fi,v700^c,if s(v700^1,v700^c)<>''then"; "d700^f fi,v700^f,')' fi,"\"v700^4*4,", "v700^5*4,", "v700^6*4,"("v700^7")","\"d700^4
7002 0 MHL,if p(v700^r) then 'A='if v700^r:', ' then v700^r else if v700^r:' 'then &unifor('G0 'v700^r),if &unifor('G2 'v700^r)<>'' then ', 'if &unifor('G2 'v700^r):'.'then if &unifor('G2 'v700^r):'. ' then &unifor('G2 'v700^r) else &unifor('G0.'&unifor('G2 'v700^r)),'. '&unifor('G2.'&unifor('G2 'v700^r)) fi else &unifor('G2 'v700^r) fi fi else v700^r fi fi fi 
7003 0 MHL,"MR="v700^p 
700 0 MHL,if p(v700^y)then"W="v700^a," "v700^d,", "v700^g,if a(v700^g) then|, |d700^b,if v700^b:'. 'or (not(v700^b:'.')) then v700^b else &unifor('G0.'v700^b),'. '&unifor('G2.'v700^b) fi fi,,if s(v700^1,v700^c,v700^f)<>''then' (',v700^1,if s(v700^1)<>''then"; "d700^c fi,v700^c,if s(v700^1,v700^c)<>''then"; "d700^f fi,v700^f,')' fi,"\"v700^4*4,", "v700^5*4,", "v700^6*4,"("v700^7")","\"d700^4/|W=|v700^r fi/ 
970 0 mhl,if p(v970^y)then"W="v970^a,| |v970^b/|W=|v970^rfi 
9701 0 MHL,"A="v970^a," "v970^b,"("v970^1")" 
9702 0 MHL,"A="v970^r 
7011 0 MHL,(|A=|v701^a,| |v701^d,|, |v701^g,if a(v701^g) then |, |d701^b,if v701^b:'. 'or (not(v701^b:'.')) then v701^b else &unifor('G0.'v701^b),'. '&unifor('G2.'v701^b) fi fi,if s(v701^1,v701^c,v701^f)<>''then' (',v701^1,if s(v701^1)<>''then|; |d701^c fi,v701^c,if s(v701^1,v701^c)<>''then|; |d701^f fi,v701^f,')' fi,|\|v701^4*4,|, |v701^5*4,|, |v701^6*4,|(|v701^7|)|,|\|d701^4,|%|d701/) 
7012 0 MHL,(if p(v701) then if p(v701^r) then 'A='if v701^r:', ' then v701^r else if v701^r:' 'then &unifor('G0 'v701^r),if &unifor('G2 'v701^r)<>'' then ', 'if &unifor('G2 'v701^r):'.'then if &unifor('G2 'v701^r):'. ' then &unifor('G2 'v701^r) else &unifor('G0.'&unifor('G2 'v701^r)),'. '&unifor('G2.'&unifor('G2 'v701^r)) fi else &unifor('G2 'v701^r) fi fi else v701^r fi fi fi fi,|%|d701/) 
7013 0 MHL,(|MR=|v701^p,|%|d701/) 
701 0 MHL,(if p(v701^y)then|W=|v701^a,| |v701^d,|, |v701^g,if a(v701^g) then |, |d701^b,if v701^b:'. 'or (not(v701^b:'.')) then v701^b else &unifor('G0.'v701^b),'. '&unifor('G2.'v701^b) fi fi,if s(v701^1,v701^c,v701^f)<>''then' (',v701^1,if s(v701^1)<>''then|; |d701^c fi,v701^c,if s(v701^1,v701^c)<>''then|; |d701^f fi,v701^f,')' fi,|\|v701^4*4,|, |v701^5*4,|, |v701^6*4,|(|v701^7|)|,|\|d701^4,/|W=|v701^r fi,|%|d701/) 
9611 0 MHL,(if p(v961^x) then |A=|d961^x,if v961^x:', 'then v961^x else if v961^x:' 'then &unifor('G0 'v961^x),', 'if &unifor('G2 'v961^x):'. ' then &unifor('G2 'v961^x) else if &unifor('G2 'v961^x):'.'then &unifor('G0.'&unifor('G2 'v961^x))'. '&unifor('G2.'&unifor('G2 'v961^x))else &unifor('G2 'v961^x)fi fi else v961^x fi fi fi,|%|d961/)/ 
9611 0 MHL,(if p(v961^a) then |A=|v961^a,| |v961^d,|, |v961^g,if a(v961^g) and p(v961^a) then |, |d961^b,if v961^b:'. 'or (not(v961^b:'.')) then v961^b else &unifor('G0.'v961^b),'. '&unifor('G2.'v961^b) fi fi,if s(v961^1,v961^c,v961^f)<>''then' (',v961^1,if s(v961^1)<>''then|; |d961^c fi,v961^c,if s(v961^1,v961^c)<>''then|; |d961^f fi,v961^f,')' fi,|\|v961^4*4,|, |v961^5*4,|, |v961^6*4,|(|v961^7|)|,|\|d961^4,fi,|%|d961/) 
9612 0 MHL,(if p(v961) then if p(v961^r) then 'A='if v961^r:', ' then v961^r else if v961^r:' 'then &unifor('G0 'v961^r),if &unifor('G2 'v961^r)<>'' then ', 'if &unifor('G2 'v961^r):'.'then if &unifor('G2 'v961^r):'. ' then &unifor('G2 'v961^r) else &unifor('G0.'&unifor('G2 'v961^r)),'. '&unifor('G2.'&unifor('G2 'v961^r)) fi else &unifor('G2 'v961^r) fi fi else v961^r fi fi fi fi,|%|d961/) 
9613 0 MHL,(|MR=|v961^p,|%|d961/) 
961 0 MHL,(if p(v961^y) then if p(v961^a) then |W=|v961^a,| |v961^d,|, |v961^g,if a(v961^g) and p(v961^a) then |, |d961^b,if v961^b:'. 'or (not(v961^b:'.')) then v961^b else &unifor('G0.'v961^b),'. '&unifor('G2.'v961^b) fi fi,if s(v961^1,v961^c,v961^f)<>''then' (',v961^1,if s(v961^1)<>''then|; |d961^c fi,v961^c,if s(v961^1,v961^c)<>''then|; |d961^f fi,v961^f,')' fi,|\|v961^4*4,|, |v961^5*4,|, |v961^6*4,|(|v961^7|)|,|\|d961^4 fi/|W=|v961^r fi,|%|d961/) 
7021 0 MHL,(|A=|v702^a,| |v702^d,|, |v702^g,if a(v702^g) then |, |d702^b,if v702^b:'. 'or (not(v702^b:'.')) then v702^b else &unifor('G0.'v702^b),'. '&unifor('G2.'v702^b) fi fi,if s(v702^1,v702^c,v702^f)<>''then' (',v702^1,if s(v702^1)<>''then|; |d702^c fi,v702^c,if s(v702^1,v702^c)<>''then|; |d702^f fi,v702^f,')' fi,|\|v702^4*4,|, |v702^5*4,|, |v702^6*4,|(|v702^7|)|,|\|d702^4,|%|d702/) 
7022 0 MHL,(if p(v702) then if p(v702^r) then 'A='if v702^r:', ' then v702^r else if v702^r:' 'then &unifor('G0 'v702^r),if &unifor('G2 'v702^r)<>'' then ', 'if &unifor('G2 'v702^r):'.'then if &unifor('G2 'v702^r):'. ' then &unifor('G2 'v702^r) else &unifor('G0.'&unifor('G2 'v702^r)),'. '&unifor('G2.'&unifor('G2 'v702^r)) fi else &unifor('G2 'v702^r) fi fi else v702^r fi fi fi fi,|%|d702/) 
7023 0 MHL,(|MR=|v702^p,|%|d702/) 
702 0 MHL,(if p(v702^y)then|W=|v702^a,| |v702^d,|, |v702^g,if a(v702^g) then |, |d702^b,if v702^b:'. 'or (not(v702^b:'.')) then v702^b else &unifor('G0.'v702^b),'. '&unifor('G2.'v702^b) fi fi,if s(v702^1,v702^c,v702^f)<>''then' (',v702^1,if s(v702^1)<>''then|; |d702^c fi,v702^c,if s(v702^1,v702^c)<>''then|; |d702^f fi,v702^f,')' fi,|\|v702^4*4,|, |v702^5*4,|, |v702^6*4,|(|v702^7|)|,|\|d702^4/|W=|v702^r fi,|%|d702/) 
9261 0 MHL,(|A=|v926^a,| |v926^d,|, |v926^g,if a(v926^g) then |, |d926^b,if v926^b:'. 'or (not(v926^b:'.')) then v926^b else &unifor('G0.'v926^b),'. '&unifor('G2.'v926^b) fi fi,if s(v926^1,v926^c,v926^f)<>''then' (',v926^1,if s(v926^1)<>''then|; |d926^c fi,v926^c,if s(v926^1,v926^c)<>''then|; |d926^f fi,v926^f,')' fi,|\|v926^4*4|\|,|%|d926/) 
9262 0 MHL,(if p(v926) then if p(v926^r) then 'A='if v926^r:', ' then v926^r else if v926^r:' 'then &unifor('G0 'v926^r),if &unifor('G2 'v926^r)<>'' then ', 'if &unifor('G2 'v926^r):'.'then if &unifor('G2 'v926^r):'. ' then &unifor('G2 'v926^r) else &unifor('G0.'&unifor('G2 'v926^r)),'. '&unifor('G2.'&unifor('G2 'v926^r)) fi else &unifor('G2 'v926^r) fi fi else v926^r fi fi fi fi,|%|d926/) 
9263 0 MHL,(|MR=|v926^p,|%|d926/) 
926 0 MHL,(if p(v926^y)then|W=|v926^a,| |v926^d,|, |v926^g,if a(v926^g) then |, |d926^b,if v926^b:'. 'or (not(v926^b:'.')) then v926^b else &unifor('G0.'v926^b),'. '&unifor('G2.'v926^b) fi fi,if s(v926^1,v926^c,v926^f)<>''then' (',v926^1,if s(v926^1)<>''then|; |d926^c fi,v926^c,if s(v926^1,v926^c)<>''then|; |d926^f fi,v926^f,')' fi,|\|v926^4*4|\|/|W=|v926^r fi,|%|d926/) 
4541 0 MHL,if p(v454^d) then 'A='if p(v454^x) then if v454^x:'1' then v454^d else &unifor('E'v454^x,&unifor('G0,'v454^d)),if &unifor('F'v454^x,v454^d)<>'' then ', 'if &unifor('F'v454^x,v454^d):'. ' then &unifor('F'v454^x,v454^d) else if &unifor('F'v454^x,v454^d):'.'then &unifor('G0.'&unifor('F'v454^x,v454^d)),'. '&unifor('G2.'&unifor('F'v454^x,v454^d)) else &unifor('F'v454^x,v454^d) fi fi fi fi else if v454^d:', ' then v454^d else if v454^d:' 'then &unifor('G0 'v454^d),if &unifor('G2 'v454^d)<>'' then ', 'if &unifor('G2 'v454^d):'.'then if &unifor('G2 'v454^d):'. ' then &unifor('G2 'v454^d) else &unifor('G0.'&unifor('G2 'v454^d)),'. '&unifor('G2.'&unifor('G2 'v454^d)) fi else &unifor('G2 'v454^d) fi fi else v454^d fi fi fi fi 
4542 0 MHL,if p(v454^e) then 'A='if p(v454^<) then if v454^<:'1' then v454^e else &unifor('E'v454^<,&unifor('G0,'v454^e)),if &unifor('F'v454^<,v454^e)<>'' then ', 'if &unifor('F'v454^<,v454^e):'. ' then &unifor('F'v454^<,v454^e) else if &unifor('F'v454^<,v454^e):'.'then &unifor('G0.'&unifor('F'v454^<,v454^e)),'. '&unifor('G2.'&unifor('F'v454^<,v454^e)) else &unifor('F'v454^<,v454^e) fi fi fi fi else if v454^e:', ' then v454^e else if v454^e:' 'then &unifor('G0 'v454^e),if &unifor('G2 'v454^e)<>'' then ', 'if &unifor('G2 'v454^e):'.'then if &unifor('G2 'v454^e):'. ' then &unifor('G2 'v454^e) else &unifor('G0.'&unifor('G2 'v454^e)),'. '&unifor('G2.'&unifor('G2 'v454^e)) fi else &unifor('G2 'v454^e) fi fi else v454^e fi fi fi fi / 
4543 0 MHL,if p(v454^f) then 'A='if p(v454^>) then if v454^>:'1' then v454^f else &unifor('E'v454^>,&unifor('G0,'v454^f)),if &unifor('F'v454^>,v454^f)<>'' then ', 'if &unifor('F'v454^>,v454^f):'. ' then &unifor('F'v454^>,v454^f) else if &unifor('F'v454^>,v454^f):'.'then &unifor('G0.'&unifor('F'v454^>,v454^f)),'. '&unifor('G2.'&unifor('F'v454^>,v454^f)) else &unifor('F'v454^>,v454^f) fi fi fi fi else if v454^f:', ' then v454^f else if v454^f:' 'then &unifor('G0 'v454^f),if &unifor('G2 'v454^f)<>'' then ', 'if &unifor('G2 'v454^f):'.'then if &unifor('G2 'v454^f):'. ' then &unifor('G2 'v454^f) else &unifor('G0.'&unifor('G2 'v454^f)),'. '&unifor('G2.'&unifor('G2 'v454^f)) fi else &unifor('G2 'v454^f) fi fi else v454^f fi fi fi fi 
4611 0 MHL,if s(v961^z)<>''then else (|A=|d461^x,if v461^x:', 'then v461^x else if v461^x:' 'then &unifor('G0 'v461^x),', 'if &unifor('G2 'v461^x):'. ' then &unifor('G2 'v461^x) else if &unifor('G2 'v461^x):'.'then &unifor('G0.'&unifor('G2 'v461^x))'. '&unifor('G2.'&unifor('G2 'v461^x))else &unifor('G2 'v461^x)fi fi else v461^x fi fi,|%|d461/) fi 
4612 0 MHL,(if ' � ��. et al. ':v461^y then else|A=|v461^y,|%|d461fi/) 
470 0 MHL,(|A=|d470^a,if v470^a:', 'then v470^a else if v470^a:' 'then &unifor('G0 'v470^a),', '&unifor('G2 'v470^a) else v470^a fi fi,|\������.���.\|d470^a,|%|d470/) 
3911 0 MHL,(|A=|v391^a,| |v391^d,|, |v391^g,if a(v391^g) then |, |v391^b fi,if s(v391^1,v391^c,v391^f)<>''then' (',v391^1,if s(v391^1)<>''then|; |d391^c fi,v391^c,if s(v391^1,v391^c)<>''then|; |d391^f fi,v391^f fi,|\������\|d391^a,|%|d391/) 
391 0 MHL,(|F=|v391^a,| |v391^d,|, |v391^g,if a(v391^g) then |, |v391^b fi,if s(v391^1,v391^c,v391^f)<>''then' (',v391^1,if s(v391^1)<>''then|; |d391^c fi,v391^c,if s(v391^1,v391^c)<>''then|; |d391^f fi,v391^f fi,|%|d391/) 
6001 0 MHL,(if p(v600) then if p(v600^a) then 'A=',if p(v600^9) then if v600^9:'1' then v600^a else &unifor('E'v600^9,v600^a),|, |v600^g if a(v600^g) then if &unifor('F'v600^9,v600^a)<>'' then ', '&unifor('F'v600^9,v600^a) fi fi fi else if v600^a:' 'then if v600^a:','then v600^a else &unifor('G0 'v600^a)', 'v600^g,if a(v600^g) then &unifor('G2 'v600^a) fi fi else v600^a,|, |v600^g fi,fi,| |v600^d,if s(v600^1,v600^c,v600^f)<>''then' (',v600^1,if s(v600^1)<>''then| ; |d600^c fi,v600^c,if s(v600^1,v600^c)<>''then| ; |d600^f fi,v600^f,')'fi,|\|v600^b|\| fi fi,|%|d600/)/ 
6002 0 MHL,(if p(v600) then if p(v600^r) then 'A='if v600^r:', ' then v600^r else if v600^r:' 'then &unifor('G0 'v600^r),if &unifor('G2 'v600^r)<>'' then ', 'if &unifor('G2 'v600^r):'.'then if &unifor('G2 'v600^r):'. ' then &unifor('G2 'v600^r) else &unifor('G0.'&unifor('G2 'v600^r)),'. '&unifor('G2.'&unifor('G2 'v600^r)) fi else &unifor('G2 'v600^r) fi fi else v600^r fi fi,|\|v600^b|\|fi fi,|%|d600/) 
6003 0 MHL,(if p(v600^r) then 'P='if v600^r:', ' then v600^r else if v600^r:' 'then &unifor('G0 'v600^r),if &unifor('G2 'v600^r)<>'' then ', 'if &unifor('G2 'v600^r):'.'then if &unifor('G2 'v600^r):'. ' then &unifor('G2 'v600^r) else &unifor('G0.'&unifor('G2 'v600^r)),'. '&unifor('G2.'&unifor('G2 'v600^r)) fi else &unifor('G2 'v600^r) fi fi else v600^r fi fi,|\|v600^b|\|fi,|%|d600/) 
600 0 MHL,(if p(v600) then if p(v600^b) or a(v600^b) and a(v600^)) then 'P='if p(v600^a) then if p(v600^9)then if v600^9:'1' then v600^a else &unifor('E'v600^9,&unifor('G0,'v600^a)),|, |v600^g if a(v600^g) then if &unifor('F'v600^9,v600^a)<>'' then ', '&unifor('F'v600^9,v600^a) fi fi fi,else if v600^a:' 'then if v600^a:','then v600^a else &unifor('G0 'v600^a)', 'v600^g,if a(v600^g) then &unifor('G2 'v600^a) fi fi else v600^a,|, |v600^g fi,fi,| |v600^d,if s(v600^1,v600^c,v600^f)<>''then' (',v600^1,if s(v600^1)<>''then| ; |d600^c fi,v600^c, if s(v600^1,v600^c)<>''then| ; |d600^f fi,v600^f,')' fi,|. |d600^z fi,v600^z,| [|v600^:|]|,| : |v600^;,| : |v600^,,| : |v600^<,|. |v600^2,|. |v600^5,|, |v600^+,if a(v600^z) and p(v600^w) then &uf('D,?I='v600^w'?,@brief') fi,if s(v600^k,v600^m,v600^8,v600^q,v600^t,v600^o,v600^j,v600^0)<>'' then | -- |v600^k,| -- |v600^m,| -- |v600^8,| -- |v600^q,| -- |v600^t,| -- |v600^o,| -- |v600^j,| -- |v600^0 fi fi fi,|%|d600/)
600 0 MHL,(if p(v600^y) then|W=|d600^a,if p(v600^9) then if v600^9:'1' then v600^a else &unifor('E'v600^9,v600^a),|, |v600^g if a(v600^g) then if &unifor('F'v600^9,v600^a)<>'' then ', '&unifor('F'v600^9,v600^a) fi fi fi else if v600^a:' 'then if v600^a:','then v600^a else &unifor('G0 'v600^a)', 'v600^g,if a(v600^g) then &unifor('G2 'v600^a) fi fi else v600^a,|, |v600^g fi,fi,| |v600^d,if s(v600^1,v600^c,v600^f)<>''then' (',v600^1,if s(v600^1)<>''then| ; |d600^c fi,v600^c,if s(v600^1,v600^c)<>''then| ; |d600^f fi,v600^f,')'fi,|\|v600^b|\|/|W=|v600^r fi,|%|d600/)/ 
9254 0 MHL,(if p(v925^f) then|A=|d925^f,if p(v925^x) then if v925^x:'1' then v925^f else &unifor('E'v925^x,v925^f),|, |v925^?,if a(v925^?) then if &unifor('F'v925^x,v925^f)<>'' then ', 'if &unifor('F'v925^x,v925^f):'. ' then &unifor('F'v925^x,v925^f) else if &unifor('F'v925^x,v925^f):'.'then &unifor('G0.'&unifor('F'v925^x,v925^f)),'. '&unifor('G2.'&unifor('F'v925^x,v925^f)) else &unifor('F'v925^x,v925^f) fi fi fi fi fi else if v925^f:',' then &unifor('G0,'v925^f),else &unifor('G0 'v925^f) fi,|, |v925^?,if a(v925^?) then if &unifor('G2 'v925^f):'. ' then ', '&unifor('G2 'v925^f) else if &unifor('G2 'v925^f):'.'then ', ' &unifor('G0.'&unifor('G2 'v925^f)),'. '&unifor('G2.'&unifor('G2 'v925^f)) fi fi fi fi fi,|%|d925/) 
9255 0 MHL,(if p(v925^2) then|A=|d925^2,if p(v925^<) then if v925^<:'1' then v925^2 else &unifor('E'v925^<,v925^2),|, |v925^,,if a(v925^,) then if &unifor('F'v925^<,v925^2)<>'' then ', 'if &unifor('F'v925^<,v925^2):'. ' then &unifor('F'v925^<,v925^2) else if &unifor('F'v925^<,v925^2):'.'then &unifor('G0.'&unifor('F'v925^<,v925^2)),'. '&unifor('G2.'&unifor('F'v925^<,v925^2)) else &unifor('F'v925^<,v925^2) fi fi fi fi fi else if v925^2:',' then &unifor('G0,'v925^2),else &unifor('G0 'v925^2) fi,|, |v925^,,if a(v925^,) then if &unifor('G2 'v925^2):'. ' then ', '&unifor('G2 'v925^2) else if &unifor('G2 'v925^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v925^2)),'. '&unifor('G2.'&unifor('G2 'v925^2)) fi fi fi fi fi,|%|d925/) 
9256 0 MHL,(if p(v925^3) then|A=|d925^3,if p(v925^>) then if v925^>:'1' then v925^3 else &unifor('E'v925^>,v925^3),|, |v925^;,if a(v925^;) then if &unifor('F'v925^>,v925^3)<>'' then ', 'if &unifor('F'v925^>,v925^3):'. ' then &unifor('F'v925^>,v925^3) else if &unifor('F'v925^>,v925^3):'.'then &unifor('G0.'&unifor('F'v925^>,v925^3)),'. '&unifor('G2.'&unifor('F'v925^>,v925^3)) else &unifor('F'v925^>,v925^3) fi fi fi fi fi else if v925^3:',' then &unifor('G0,'v925^3),else &unifor('G0 'v925^3) fi,|, |v925^;,if a(v925^;) then if &unifor('G2 'v925^3):'. ' then ', '&unifor('G2 'v925^3) else if &unifor('G2 'v925^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v925^3)),'. '&unifor('G2.'&unifor('G2 'v925^3)) fi fi fi fi fi,|%|d925/) 
925 0 MHL, (if p(v925^y) then|W=|d925^f,if p(v925^x) then if v925^x:'1' then v925^f else &unifor('E'v925^x,v925^f),|, |v925^?,if a(v925^?) then if &unifor('F'v925^x,v925^f)<>'' then ', 'if &unifor('F'v925^x,v925^f):'. ' then &unifor('F'v925^x,v925^f) else if &unifor('F'v925^x,v925^f):'.'then &unifor('G0.'&unifor('F'v925^x,v925^f)),'. '&unifor('G2.'&unifor('F'v925^x,v925^f)) else &unifor('F'v925^x,v925^f) fi fi fi fi fi else if v925^f:',' then &unifor('G0,'v925^f),else &unifor('G0 'v925^f) fi,|, |v925^?,if a(v925^?) then if &unifor('G2 'v925^f):'. ' then ', '&unifor('G2 'v925^f) else if &unifor('G2 'v925^f):'.'then ', ' &unifor('G0.'&unifor('G2 'v925^f)),'. '&unifor('G2.'&unifor('G2 'v925^f)) fi fi fi fi fi,|%|d925/) 
925 0 MHL, (if p(v925^z) then|W=|d925^2,if p(v925^<) then if v925^<:'1' then v925^2 else &unifor('E'v925^<,v925^2),|, |v925^,,if a(v925^,) then if &unifor('F'v925^<,v925^2)<>'' then ', 'if &unifor('F'v925^<,v925^2):'. ' then &unifor('F'v925^<,v925^2) else if &unifor('F'v925^<,v925^2):'.'then &unifor('G0.'&unifor('F'v925^<,v925^2)),'. '&unifor('G2.'&unifor('F'v925^<,v925^2)) else &unifor('F'v925^<,v925^2) fi fi fi fi fi else if v925^2:',' then &unifor('G0,'v925^2),else &unifor('G0 'v925^2) fi,|, |v925^,,if a(v925^,) then if &unifor('G2 'v925^2):'. ' then ', '&unifor('G2 'v925^2) else if &unifor('G2 'v925^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v925^2)),'. '&unifor('G2.'&unifor('G2 'v925^2)) fi fi fi fi fi,|%|d925/) 
925 0 MHL, (if p(v925^n) then|W=|d925^3,if p(v925^>) then if v925^>:'1' then v925^3 else &unifor('E'v925^>,v925^3),|, |v925^;,if a(v925^;) then if &unifor('F'v925^>,v925^3)<>'' then ', 'if &unifor('F'v925^>,v925^3):'. ' then &unifor('F'v925^>,v925^3) else if &unifor('F'v925^>,v925^3):'.'then &unifor('G0.'&unifor('F'v925^>,v925^3)),'. '&unifor('G2.'&unifor('F'v925^>,v925^3)) else &unifor('F'v925^>,v925^3) fi fi fi fi fi else if v925^3:',' then &unifor('G0,'v925^3),else &unifor('G0 'v925^3) fi,|, |v925^;,if a(v925^;) then if &unifor('G2 'v925^3):'. ' then ', '&unifor('G2 'v925^3) else if &unifor('G2 'v925^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v925^3)),'. '&unifor('G2.'&unifor('G2 'v925^3)) fi fi fi fi fi,|%|d925/) 
9221 0 MHL,(if p(v922^f) then|A=|d922^f,if p(v922^x) then if v922^x:'1' then v922^f else &unifor('E'v922^x,v922^f),|, |v922^?,if a(v922^?) then if &unifor('F'v922^x,v922^f)<>'' then ', 'if &unifor('F'v922^x,v922^f):'. ' then &unifor('F'v922^x,v922^f) else if &unifor('F'v922^x,v922^f):'.'then &unifor('G0.'&unifor('F'v922^x,v922^f)),'. '&unifor('G2.'&unifor('F'v922^x,v922^f)) else &unifor('F'v922^x,v922^f) fi fi fi fi fi else if v922^f:',' then &unifor('G0,'v922^f),else &unifor('G0 'v922^f) fi,|, |v922^?,if a(v922^?) then if &unifor('G2 'v922^f):'. ' then ', '&unifor('G2 'v922^f) else if &unifor('G2 'v922^f):'.'then ', ' &unifor('G0.'&unifor('G2 'v922^f)),'. '&unifor('G2.'&unifor('G2 'v922^f)) fi fi fi fi fi,|\|v922^q*4|\|,|%|d922/) 
9222 0 MHL,(if p(v922^2) then|A=|d922^2,if p(v922^<) then if v922^<:'1' then v922^2 else &unifor('E'v922^<,v922^2),|, |v922^,,if a(v922^,) then if &unifor('F'v922^<,v922^2)<>'' then ', 'if &unifor('F'v922^<,v922^2):'. ' then &unifor('F'v922^<,v922^2) else if &unifor('F'v922^<,v922^2):'.'then &unifor('G0.'&unifor('F'v922^<,v922^2)),'. '&unifor('G2.'&unifor('F'v922^<,v922^2)) else &unifor('F'v922^<,v922^2) fi fi fi fi fi else if v922^2:',' then &unifor('G0,'v922^2),else &unifor('G0 'v922^2) fi,|, |v922^,,if a(v922^,) then if &unifor('G2 'v922^2):'. ' then ', '&unifor('G2 'v922^2) else if &unifor('G2 'v922^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v922^2)),'. '&unifor('G2.'&unifor('G2 'v922^2)) fi fi fi fi fi,|\|v922^s*4|\|,|%|d922/) 
9223 0 MHL,(if p(v922^3) then|A=|d922^3,if p(v922^>) then if v922^>:'1' then v922^3 else &unifor('E'v922^>,v922^3),|, |v922^;,if a(v922^;) then if &unifor('F'v922^>,v922^3)<>'' then ', 'if &unifor('F'v922^>,v922^3):'. ' then &unifor('F'v922^>,v922^3) else if &unifor('F'v922^>,v922^3):'.'then &unifor('G0.'&unifor('F'v922^>,v922^3)),'. '&unifor('G2.'&unifor('F'v922^>,v922^3)) else &unifor('F'v922^>,v922^3) fi fi fi fi fi else if v922^3:',' then &unifor('G0,'v922^3),else &unifor('G0 'v922^3) fi,|, |v922^;,if a(v922^;) then if &unifor('G2 'v922^3):'. ' then ', '&unifor('G2 'v922^3) else if &unifor('G2 'v922^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v922^3)),'. '&unifor('G2.'&unifor('G2 'v922^3)) fi fi fi fi fi,|\|v922^t*4|\|,|%|d922/) 
9224 0 MHL,(|MR=|v922^=,|%|d922/)
9225 0 MHL,(|MR=|v922^+,|%|d922/)
9226 0 MHL,(|MR=|v922^-,|%|d922/)
922 0 MHL, (if p(v922^y) then|W=|d922^f,if p(v922^x) then if v922^x:'1' then v922^f else &unifor('E'v922^x,v922^f),|, |v922^?,if a(v922^?) then if &unifor('F'v922^x,v922^f)<>'' then ', 'if &unifor('F'v922^x,v922^f):'. ' then &unifor('F'v922^x,v922^f) else if &unifor('F'v922^x,v922^f):'.'then &unifor('G0.'&unifor('F'v922^x,v922^f)),'. '&unifor('G2.'&unifor('F'v922^x,v922^f)) else &unifor('F'v922^x,v922^f) fi fi fi fi fi else if v922^f:',' then &unifor('G0,'v922^f),else &unifor('G0 'v922^f) fi,|, |v922^?,if a(v922^?) then if &unifor('G2 'v922^f):'. ' then ', '&unifor('G2 'v922^f) else if &unifor('G2 'v922^f):'.'then ', ' &unifor('G0.'&unifor('G2 'v922^f)),'. '&unifor('G2.'&unifor('G2 'v922^f)) fi fi fi fi fi,|%|d922/) 
922 0 MHL, (if p(v922^z) then|W=|d922^2,if p(v922^<) then if v922^<:'1' then v922^2 else &unifor('E'v922^<,v922^2),|, |v922^,,if a(v922^,) then if &unifor('F'v922^<,v922^2)<>'' then ', 'if &unifor('F'v922^<,v922^2):'. ' then &unifor('F'v922^<,v922^2) else if &unifor('F'v922^<,v922^2):'.'then &unifor('G0.'&unifor('F'v922^<,v922^2)),'. '&unifor('G2.'&unifor('F'v922^<,v922^2)) else &unifor('F'v922^<,v922^2) fi fi fi fi fi else if v922^2:',' then &unifor('G0,'v922^2),else &unifor('G0 'v922^2) fi,|, |v922^,,if a(v922^,) then if &unifor('G2 'v922^2):'. ' then ', '&unifor('G2 'v922^2) else if &unifor('G2 'v922^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v922^2)),'. '&unifor('G2.'&unifor('G2 'v922^2)) fi fi fi fi fi,|%|d922/) 
922 0 MHL, (if p(v922^n) then|W=|d922^3,if p(v922^>) then if v922^>:'1' then v922^3 else &unifor('E'v922^>,v922^3),|, |v922^;,if a(v922^;) then if &unifor('F'v922^>,v922^3)<>'' then ', 'if &unifor('F'v922^>,v922^3):'. ' then &unifor('F'v922^>,v922^3) else if &unifor('F'v922^>,v922^3):'.'then &unifor('G0.'&unifor('F'v922^>,v922^3)),'. '&unifor('G2.'&unifor('F'v922^>,v922^3)) else &unifor('F'v922^>,v922^3) fi fi fi fi fi else if v922^3:',' then &unifor('G0,'v922^3),else &unifor('G0 'v922^3) fi,|, |v922^;,if a(v922^;) then if &unifor('G2 'v922^3):'. ' then ', '&unifor('G2 'v922^3) else if &unifor('G2 'v922^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v922^3)),'. '&unifor('G2.'&unifor('G2 'v922^3)) fi fi fi fi fi,|%|d922/) 
3301 0 MHL,(if p(v330^f) then|A=|d330^f,if p(v330^x) then if v330^x:'1' then v330^f else &unifor('E'v330^x,v330^f),|, |v330^?,if a(v330^?) then if &unifor('F'v330^x,v330^f)<>'' then ', 'if &unifor('F'v330^x,v330^f):'. ' then &unifor('F'v330^x,v330^f) else if &unifor('F'v330^x,v330^f):'.'then &unifor('G0.'&unifor('F'v330^x,v330^f)),'. '&unifor('G2.'&unifor('F'v330^x,v330^f)) else &unifor('F'v330^x,v330^f) fi fi fi fi fi else if v330^f:',' then &unifor('G0,'v330^f),else &unifor('G0 'v330^f) fi,|, |v330^?,if a(v330^?) then if &unifor('G2 'v330^f):'. ' then ', '&unifor('G2 'v330^f) else if &unifor('G2 'v330^f):'.'then ', ' &unifor('G0.'&unifor('G2 'v330^f)),'. '&unifor('G2.'&unifor('G2 'v330^f)) fi fi fi fi,|\|v330^q*4|\| fi,|%|d330/) 
3302 0 MHL,(if p(v330^2) then|A=|d330^2,if p(v330^<) then if v330^<:'1' then v330^2 else &unifor('E'v330^<,v330^2),|, |v330^,,if a(v330^,) then if &unifor('F'v330^<,v330^2)<>'' then ', 'if &unifor('F'v330^<,v330^2):'. ' then &unifor('F'v330^<,v330^2) else if &unifor('F'v330^<,v330^2):'.'then &unifor('G0.'&unifor('F'v330^<,v330^2)),'. '&unifor('G2.'&unifor('F'v330^<,v330^2)) else &unifor('F'v330^<,v330^2) fi fi fi fi fi else if v330^2:',' then &unifor('G0,'v330^2),else &unifor('G0 'v330^2) fi,|, |v330^,,if a(v330^,) then if &unifor('G2 'v330^2):'. ' then ', '&unifor('G2 'v330^2) else if &unifor('G2 'v330^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v330^2)),'. '&unifor('G2.'&unifor('G2 'v330^2)) fi fi fi fi,|\|v330^s*4|\| fi,|%|d330/) 
3303 0 MHL,(if p(v330^3) then|A=|d330^3,if p(v330^>) then if v330^>:'1' then v330^3 else &unifor('E'v330^>,v330^3),|, |v330^;,if a(v330^;) then if &unifor('F'v330^>,v330^3)<>'' then ', 'if &unifor('F'v330^>,v330^3):'. ' then &unifor('F'v330^>,v330^3) else if &unifor('F'v330^>,v330^3):'.'then &unifor('G0.'&unifor('F'v330^>,v330^3)),'. '&unifor('G2.'&unifor('F'v330^>,v330^3)) else &unifor('F'v330^>,v330^3) fi fi fi fi fi else if v330^3:',' then &unifor('G0,'v330^3),else &unifor('G0 'v330^3) fi,|, |v330^;,if a(v330^;) then if &unifor('G2 'v330^3):'. ' then ', '&unifor('G2 'v330^3) else if &unifor('G2 'v330^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v330^3)),'. '&unifor('G2.'&unifor('G2 'v330^3)) fi fi fi fi,|\|v330^t*4|\| fi,|%|d330/) 
3304 0 MHL,(|MR=|v330^=,|%|d330/)
3305 0 MHL,(|MR=|v330^+,|%|d330/)
3306 0 MHL,(|MR=|v330^-,|%|d330/)
330 0 MHL, (if p(v330^y) then|W=|d330^f,if p(v330^x) then if v330^x:'1' then v330^f else &unifor('E'v330^x,v330^f),|, |v330^?,if a(v330^?) then if &unifor('F'v330^x,v330^f)<>'' then ', 'if &unifor('F'v330^x,v330^f):'. ' then &unifor('F'v330^x,v330^f) else if &unifor('F'v330^x,v330^f):'.'then &unifor('G0.'&unifor('F'v330^x,v330^f)),'. '&unifor('G2.'&unifor('F'v330^x,v330^f)) else &unifor('F'v330^x,v330^f) fi fi fi fi fi else if v330^f:',' then &unifor('G0,'v330^f),else &unifor('G0 'v330^f) fi,|, |v330^?,if a(v330^?) then if &unifor('G2 'v330^f):'. ' then ', '&unifor('G2 'v330^f) else if &unifor('G2 'v330^f):'.'then ', ' &unifor('G0.'&unifor('G2 'v330^f)),'. '&unifor('G2.'&unifor('G2 'v330^f)) fi fi fi fi fi,|%|d330/) 
330 0 MHL, (if p(v330^z) then|W=|d330^2,if p(v330^<) then if v330^<:'1' then v330^2 else &unifor('E'v330^<,v330^2),|, |v330^,,if a(v330^,) then if &unifor('F'v330^<,v330^2)<>'' then ', 'if &unifor('F'v330^<,v330^2):'. ' then &unifor('F'v330^<,v330^2) else if &unifor('F'v330^<,v330^2):'.'then &unifor('G0.'&unifor('F'v330^<,v330^2)),'. '&unifor('G2.'&unifor('F'v330^<,v330^2)) else &unifor('F'v330^<,v330^2) fi fi fi fi fi else if v330^2:',' then &unifor('G0,'v330^2),else &unifor('G0 'v330^2) fi,|, |v330^,,if a(v330^,) then if &unifor('G2 'v330^2):'. ' then ', '&unifor('G2 'v330^2) else if &unifor('G2 'v330^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v330^2)),'. '&unifor('G2.'&unifor('G2 'v330^2)) fi fi fi fi fi,|%|d330/) 
330 0 MHL, (if p(v330^n) then|W=|d330^3,if p(v330^>) then if v330^>:'1' then v330^3 else &unifor('E'v330^>,v330^3),|, |v330^;,if a(v330^;) then if &unifor('F'v330^>,v330^3)<>'' then ', 'if &unifor('F'v330^>,v330^3):'. ' then &unifor('F'v330^>,v330^3) else if &unifor('F'v330^>,v330^3):'.'then &unifor('G0.'&unifor('F'v330^>,v330^3)),'. '&unifor('G2.'&unifor('F'v330^>,v330^3)) else &unifor('F'v330^>,v330^3) fi fi fi fi fi else if v330^3:',' then &unifor('G0,'v330^3),else &unifor('G0 'v330^3) fi,|, |v330^;,if a(v330^;) then if &unifor('G2 'v330^3):'. ' then ', '&unifor('G2 'v330^3) else if &unifor('G2 'v330^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v330^3)),'. '&unifor('G2.'&unifor('G2 'v330^3)) fi fi fi fi fi,|%|d330/) 
4811 0 MHL,(if p(v481^c) then if p(v481^x) then|A=|d481^x,if p(v481^9) then if v481^9:'1' then v481^x else &unifor('E'v481^9,v481^x),|, |v481^?,if a(v481^?) then if &unifor('F'v481^9,v481^x)<>'' then ', 'if &unifor('F'v481^9,v481^x):'. ' then &unifor('F'v481^9,v481^x) else if &unifor('F'v481^9,v481^x):'.'then &unifor('G0.'&unifor('F'v481^9,v481^x)),'. '&unifor('G2.'&unifor('F'v481^9,v481^x)) else &unifor('F'v481^9,v481^x) fi fi fi fi fi else if v481^x:',' then &unifor('G0,'v481^x),else &unifor('G0 'v481^x) fi,|, |v481^?,if a(v481^?) then if &unifor('G2 'v481^x):'. ' then ', '&unifor('G2 'v481^x) else if &unifor('G2 'v481^x):'.'then ', ' &unifor('G0.'&unifor('G2 'v481^x)),'. '&unifor('G2.'&unifor('G2 'v481^x)) fi fi fi fi fi fi,|%|d481/) 
4812 0 MHL,(if p(v481^c) then if p(v481^2) then|A=|d481^2,if p(v481^<) then if v481^<:'1' then v481^2 else &unifor('E'v481^<,v481^2),|, |v481^,,if a(v481^,) then if &unifor('F'v481^<,v481^2)<>'' then ', 'if &unifor('F'v481^<,v481^2):'. ' then &unifor('F'v481^<,v481^2) else if &unifor('F'v481^<,v481^2):'.'then &unifor('G0.'&unifor('F'v481^<,v481^2)),'. '&unifor('G2.'&unifor('F'v481^<,v481^2)) else &unifor('F'v481^<,v481^2) fi fi fi fi fi else if v481^2:',' then &unifor('G0,'v481^2),else &unifor('G0 'v481^2) fi,|, |v481^,,if a(v481^,) then if &unifor('G2 'v481^2):'. ' then ', '&unifor('G2 'v481^2) else if &unifor('G2 'v481^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v481^2)),'. '&unifor('G2.'&unifor('G2 'v481^2)) fi fi fi fi fi fi,|%|d481/) 
4813 0 MHL,(if p(v481^c) then if p(v481^3) then|A=|d481^3,if p(v481^>) then if v481^>:'1' then v481^3 else &unifor('E'v481^>,v481^3),|, |v481^;,if a(v481^;) then if &unifor('F'v481^>,v481^3)<>'' then ', 'if &unifor('F'v481^>,v481^3):'. ' then &unifor('F'v481^>,v481^3) else if &unifor('F'v481^>,v481^3):'.'then &unifor('G0.'&unifor('F'v481^>,v481^3)),'. '&unifor('G2.'&unifor('F'v481^>,v481^3)) else &unifor('F'v481^>,v481^3) fi fi fi fi fi else if v481^3:',' then &unifor('G0,'v481^3),else &unifor('G0 'v481^3) fi,|, |v481^;,if a(v481^;) then if &unifor('G2 'v481^3):'. ' then ', '&unifor('G2 'v481^3) else if &unifor('G2 'v481^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v481^3)),'. '&unifor('G2.'&unifor('G2 'v481^3)) fi fi fi fi fi fi,|%|d481/) 
4881 0 MHL,(if p(v488^c) then if p(v488^x) then|A=|d488^x,if p(v488^9) then if v488^9:'1' then v488^x else &unifor('E'v488^9,v488^x),|, |v488^?,if a(v488^?) then if &unifor('F'v488^9,v488^x)<>'' then ', 'if &unifor('F'v488^9,v488^x):'. ' then &unifor('F'v488^9,v488^x) else if &unifor('F'v488^9,v488^x):'.'then &unifor('G0.'&unifor('F'v488^9,v488^x)),'. '&unifor('G2.'&unifor('F'v488^9,v488^x)) else &unifor('F'v488^9,v488^x) fi fi fi fi fi else if v488^x:',' then &unifor('G0,'v488^x),else &unifor('G0 'v488^x) fi,|, |v488^?,if a(v488^?) then if &unifor('G2 'v488^x):'. ' then ', '&unifor('G2 'v488^x) else if &unifor('G2 'v488^x):'.'then ', ' &unifor('G0.'&unifor('G2 'v488^x)),'. '&unifor('G2.'&unifor('G2 'v488^x)) fi fi fi fi fi fi,|%|d488/) 
4882 0 MHL,(if p(v488^c) then if p(v488^2) then|A=|d488^2,if p(v488^<) then if v488^<:'1' then v488^2 else &unifor('E'v488^<,v488^2),|, |v488^,,if a(v488^,) then if &unifor('F'v488^<,v488^2)<>'' then ', 'if &unifor('F'v488^<,v488^2):'. ' then &unifor('F'v488^<,v488^2) else if &unifor('F'v488^<,v488^2):'.'then &unifor('G0.'&unifor('F'v488^<,v488^2)),'. '&unifor('G2.'&unifor('F'v488^<,v488^2)) else &unifor('F'v488^<,v488^2) fi fi fi fi fi else if v488^2:',' then &unifor('G0,'v488^2),else &unifor('G0 'v488^2) fi,|, |v488^,,if a(v488^,) then if &unifor('G2 'v488^2):'. ' then ', '&unifor('G2 'v488^2) else if &unifor('G2 'v488^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v488^2)),'. '&unifor('G2.'&unifor('G2 'v488^2)) fi fi fi fi fi fi,|%|d488/) 
4883 0 MHL,(if p(v488^c) then if p(v488^3) then|A=|d488^3,if p(v488^>) then if v488^>:'1' then v488^3 else &unifor('E'v488^>,v488^3),|, |v488^;,if a(v488^;) then if &unifor('F'v488^>,v488^3)<>'' then ', 'if &unifor('F'v488^>,v488^3):'. ' then &unifor('F'v488^>,v488^3) else if &unifor('F'v488^>,v488^3):'.'then &unifor('G0.'&unifor('F'v488^>,v488^3)),'. '&unifor('G2.'&unifor('F'v488^>,v488^3)) else &unifor('F'v488^>,v488^3) fi fi fi fi fi else if v488^3:',' then &unifor('G0,'v488^3),else &unifor('G0 'v488^3) fi,|, |v488^;,if a(v488^;) then if &unifor('G2 'v488^3):'. ' then ', '&unifor('G2 'v488^3) else if &unifor('G2 'v488^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v488^3)),'. '&unifor('G2.'&unifor('G2 'v488^3)) fi fi fi fi fi fi,|%|d488/) 
/*IBIS_KL_COL
3710 8 MHL,'/K=/'(v710|%|/) 
3971 8 MHL,'/K=/'(v971|%|/) 
3461 8 MHL,'/K=/'(if a(v962) then v461^b fi,|%|d461/) 
3961 8 MHL,'/K=/'(if a(v962) then if p(v961^b) and a(v961^a) then v961^b fi fi,|%|d961/) 
3962 8 MHL,'/K=/'(v962|%|/) 
3601 8 MHL,'/K=/'(v601^a,' 'v601^p,|%|d601/) 
3711 8 MHL,'/K=/'(v711|%|/) 
3972 8 MHL,'/K=/'(v972|%|/) 
3981 8 MHL,'/K=/'(v981^a,|%|d981/) 
3982 8 MHL,'/K=/'(v981^b,|%|d981/) 
/*IBIS_COL
710 0 MHL,if p(v710^a) then'M=',&unifor("9"v710^a,if s(v710^nv710^c)<>''then' ('v710^n" ; ",v710^c')'fi,". "v710^b,if s(v710^dv710^fv710^e)<>''then' ('v710^d" ; ",v710^f,if p(v710^f)then" ; "v710^eelse v710^efi,"/ "v710^h,"/ "v710^i')'fi,if p(v971)then". "d710fi,v971^b,if s(v971^dv971^fv971^e)<>''then' ('v971^d" ; ",v971^f,if v971^f<>''then" ; "v971^eelse v971^efi,"/ "v971^h,"/ "v971^i')'fi) fi 
7101 0 MHL,if p(v710^x) then"M="d710^b,&unifor("9"v710^b) fi 
971 0 MHL,if p(v971^b) then'M=',&unifor("9"v971^b,if s(v971^dv971^f,v971^e)<>''then' ('v971^d" ; ",v971^f,if v971^f<>''then" ; "v971^eelse v971^efi,"/ "v971^h,"/ "v971^i')'fi) fi 
711 0 MHL,(if p(v711^a) then'M=',&unifor(|9|v711^a,if s(v711^nv711^c)<>''then' ('v711^n| ; |,v711^c')'fi,|. |v711^b) fi,|%|d711/) 
7111 0 MHL,(if p(v711^b) and p(v711^x) then'M=',&unifor('9'v711^b) fi |%|d711/) 
972 0 MHL,(if p(v972^a) then'M=',&unifor(|9|v972^a,if s(v972^dv972^fv972^e)<>''then' ('v972^d| ; |,v972^f,if p(v972^f)then| ; |v972^eelse v972^efi,|/ |v972^h,|/ |v972^i')'fi) fi,|%|d972/) 
981 0 MHL,(|M=|d981^a,&unifor(|9|v981^a),|%|d981/)(|M=|d981^b,&unifor(|9|v981^b),|%|d981/) 
461 0 MHL,if p(v962) then else (|M=|d461^b,&unifor(|9|v461^b),|%|d461/) fi 
961 0 MHL,if p(v962) then else (if p(v961) then if p(v961^b) and a(v961^a) then'M=',&unifor(|9|v961^b) fi fi,|%|d961/) fi 
962 0 MHL,(if p(v962^a)then'M=',&unifor(|9|v962^a,if s(v962^n,v962^c)<>''then' ('v962^n| ; |,v962^c')'fi,|. |v962^b,if s(v962^d,v962^f,v962^e)<>''then' ('v962^d| ; |,v962^f,if p(v962^f)then| ; |v962^e else v962^e fi,|/ |v962^h,|/ |v962^i,')'fi) fi,|%|d962/) 
9621 0 MHL,(if p(v962^b) and p(v962^x) then'M=',&unifor('9'v962^b) fi,|%|d962/) 
601 0 MHL,(if p(v601) then 'M=',if p(v601^a) then &unifor(|9|v601^a) else if p(v601^p) then &unifor(|9|v601^p,if s(v601^n,v601^c)<>''then' ('v601^n| ; |,v601^c')'fi,|. |v601^l,if s(v601^d,v601^f,v601^e)<>''then' ('v601^d| ; |,v601^f,if p(v601^f)then| ; |v601^e else v601^e fi,|/ |v601^h,|/ |v601^i,')'fi) fi,|\|v601^b|\| fi,if a(v601^b) then|\� ���\|d601^a fi fi,|%|d601/) 
601 0 MHL,(if p(v601) then if p(v601^b) then 'P='v601^a,if a(v601^a) then v601^p,if p(v601^n)or p(v601^c) then' ('v601^n| ; |,v601^c,')'fi,|. |v601^l,if s(v601^d,v601^f,v601^e)<>''then' ('v601^d| ; |,v601^f,if p(v601^f) then| ; |v601^e else v601^e fi,| / |v601^h,| / |v601^i')' fi fi,if s(v601^a,v601^p)<>'' then |. |d601^z fi,v601^z,| [|v601^:|]|,| : |v601^;,| : |v601^,,| : |v601^<,|. |v601^2,|. |v601^5,|, |v601^+,if a(v601^z) and p(v601^w) then '\��������-����'v601^w'\' fi,|\|v601^b|\| else if p(v601^a) and a(v601^b) then |P=|v601^a|\� ���\| fi fi fi,|%|d601/)
6011 0 MHL,(if p(v601^L) and p(v601^x) then'M=',&unifor('9'v601^L) fi,|%|d601/) 
330 0 (if p(v330) then |M=|v330^8 fi,|%|d330/)
922 0 (if p(v922) then |M=|v922^8 fi,|%|d922/)
/*IBIS_INDEX
629 0 MHL,"KRV="d629,&unifor("9"v629^b)/"KRV=�����"d629
328 0 MHL,"KNS="v328^n/"KNS="v328^0/"KNS="v328^9 
675 0 MHL,(|U=|v675^*,|%|d675/) 
621 0 MHL,if a(v675)then(|U=|v621^*,|%|d621/)fi 
686 0 MHL,(|RIN=|v686,|%|d686/) 
964 0 MHL,(if p(v964)then|R=|v964.2/if v964*2.1:'.'then|R=|v964.5/fi/if v964*5.1:'.'then|R=|v964/fi fi/) 
60 0 MHL,"RZN="v60
606 0 &uf('+7W606#'(if v606^a<>''then/v606^a,fi,| -- |v606^b,| -- |v606^c,| -- |v606^d,| -- |v606^g,| -- |v606^e,| -- |v606^o,|, |v606^h, if a(v606^a)then / v606^b,| -- |v606^c,| -- |v606^d,| -- |v606^g,| -- |v606^e,| -- |v606^o,|, |v606^h,|(������.)|d606 fi)),MHL,(if p(g606) then'S='&unifor(|9|g606),|%|d606 fi/),
6061 0 MHL,(|PS=|v606^a,|%|d606/) 
6062 0 MHL,(|PS=|v606^b,|%|d606/) 
6063 0 MHL,(|PS=|v606^c,|%|d606/) 
6064 0 MHL,(|PS=|v606^d,|%|d606/) 
6065 0 MHL,(|GS=|v606^g,|%|d606/) 
6066 0 MHL,(|GS=|v606^e,|%|d606/) 
6067 0 MHL,(|GS=|v606^o,|%|d606/) 
6068 0 MHL,(|HS=|v606^h,|%|d606/) 
607 0 MHL,(if p(v607^a) then'GEO='&unifor(|9|v607^a,| -- |v607^b,| -- |v607^c,| -- |v607^d,| -- |v607^g,| -- |v607^e,| -- |v607^o,|, |v607^h,| -- |v607^9) fi,|%|d607/) 
6071 0 MHL,(|GS=|v607^a,|%|d607/) 
6072 0 MHL,(|PS=|v607^b,|%|d607/) 
6073 0 MHL,(|PS=|v607^c,|%|d607/) 
6074 0 MHL,(|PS=|v607^d,|%|d607/) 
6075 0 MHL,(|GS=|v607^g,|%|d607/) 
6076 0 MHL,(|GS=|v607^e,|%|d607/) 
6077 0 MHL,(|GS=|v607^o,|%|d607/) 
6078 0 MHL,(|HS=|v607^h,|%|d607/) 
6191 0 MHL,(|PS=|v619^d,|%|d619/) 
6192 0 MHL,(|GS=|v619^o,|%|d619/) 
6193 0 MHL,(|HS=|v619^h,|%|d619/) 
600 0 MHL,(if p(v600) then if a(v600^b) and p(v600^)) then 'S='if p(v600^a) then if p(v600^9)then if v600^9:'1' then v600^a else  &unifor('E'v600^9,&unifor('G0,'v600^a)),|, |v600^g if a(v600^g) then if &unifor('F'v600^9,v600^a)<>'' then ', '&unifor('F'v600^9,v600^a) fi fi fi else if v600^a:' 'then if v600^a:','then v600^a else &unifor('G0 'v600^a)', 'v600^g,if a(v600^g) then &unifor('G2 'v600^a) fi fi else v600^a,|, |v600^g fi,fi,| |v600^d,if s(v600^1,v600^c,v600^f)<>''then' (',v600^1,if s(v600^1)<>''then| ; |d600^c fi,v600^c, if s(v600^1,v600^c)<>''then| ; |d600^f fi,v600^f,')' fi,|. |d600^z fi,&uf('9'v600^z),| [|v600^:|]|,| : |v600^;,| : |v600^,,| : |v600^<,|. |v600^2,|. |v600^5,|, |v600^+,if a(v600^z) and p(v600^w) then &uf('D,?I='v600^w'?,@brief') fi,if s(v600^k,v600^m,v600^8,v600^q,v600^t,v600^o,v600^j,v600^0)<>'' then | -- |v600^k,| -- |v600^m,| -- |v600^8,| -- |v600^q,| -- |v600^t,| -- |v600^o,| -- |v600^j,| -- |v600^0 fi fi fi,|%|d600/)
6002 0 MHL,(|PS=|v600^k,|%|d600/) 
6003 0 MHL,(|PS=|v600^m,|%|d600/) 
6004 0 MHL,(|PS=|v600^8,|%|d600/) 
6005 0 MHL,(|GS=|v600^q,|%|d600/) 
6006 0 MHL,(|GS=|v600^t,|%|d600/) 
6007 0 MHL,(|GS=|v600^o,|%|d600/) 
6008 0 MHL,(|HS=|v600^j,|%|d600/) 
601 0 MHL,(if p(v601) then if a(v601^b) then 'S='v601^a,if a(v601^a) then v601^p,if p(v601^n)or p(v601^c) then' ('v601^n| ; |,v601^c,')'fi,|. |v601^l,if s(v601^d,v601^f,v601^e)<>''then' ('v601^d| ; |,v601^f,if p(v601^f) then| ; |v601^e else v601^e fi,| / |v601^h,| / |v601^i')' fi fi,if s(v601^a,v601^p)<>'' then |. |d601^z fi,v601^z,| [|v601^:|]|,| : |v601^;,| : |v601^,,| : |v601^<,|. |v601^2,|. |v601^5,|, |v601^+,if a(v601^z) and p(v601^w) then &uf('D,?I='v601^w'?,@brief') fi,if s(v601^k,v601^m,v601^8,v601^q,v601^t,v601^o,v601^j,v601^0)<>'' then | -- |v601^k,| -- |v601^m,| -- |v601^8,| -- |v601^q,| -- |v601^t,| -- |v601^o,| -- |v601^j,| -- |v601^0 fi fi fi,|%|d601/)
6012 0 MHL,(|PS=|v601^k,|%|d601/) 
6013 0 MHL,(|PS=|v601^m,|%|d601/) 
6014 0 MHL,(|PS=|v601^8,|%|d601/) 
6015 0 MHL,(|GS=|v601^q,|%|d601/) 
6016 0 MHL,(|GS=|v601^t,|%|d601/) 
6017 0 MHL,(|GS=|v601^o,|%|d601/) 
6018 0 MHL,(|HS=|v601^j,|%|d601/) 
/*IBIS_KL_RUB
610 0 MHL,if s(v910^a):'u' and s(v330^5,v922^5):'; 'then (|S=|v610,|%|d610/) fi/ 
66 0 (mpl,if v610:'<'then else MHL,if v610:' 'then'K='&unifor('9'v610) fi fi,|%|d610/)/ 
66 0 mhl,(if v330^5:' 'then'K='&unifor('9'v330^5) fi,|%|d330/),(if v330^6:' 'then'K='&unifor('9'v330^6) fi,|%|d330/),(if v330^7:' 'then'K='&unifor('9'v330^7) fi,|%|d330/) 
66 0 mhl,(if v922^5:' 'then'K='&unifor('9'v922^5) fi,|%|d922/),(if v922^6:' 'then'K='&unifor('9'v922^6) fi,|%|d922/),(if v922^7:' 'then'K='&unifor('9'v922^7) fi,|%|d922/) 
66 0 mhl,(if v481^5:' 'then'K='&unifor('9'v481^5) fi,|%|d481/),(if v481^6:' 'then'K='&unifor('9'v481^6) fi,|%|d481/),(if v481^7:' 'then'K='&unifor('9'v481^7) fi,|%|d481/) 
66 0 mhl,(if v488^5:' 'then'K='&unifor('9'v488^5) fi,|%|d488/),(if v488^6:' 'then'K='&unifor('9'v488^6) fi,|%|d488/),(if v488^7:' 'then'K='&unifor('9'v488^7) fi,|%|d488/) 
66 0 mhl,(if v965:' 'then'K='&unifor('9'v965) fi,|%|d965/),(|K=|v981^d.4,| |v981^n/)/"K="d629,&unifor("9"v629^b) 
6610 6 '/K=/'(v610|%|/), 
6629 6 '/K=/'(v929|%|/), 
6316 6 '/K=/'if a(v929) then (v316^c,|%|d316/) fi 
6300 6 '/K=/'(v300|%|/) 
6331 6 '/K=/'(v331|%|/) 
6200 6 '/K=/'(v200^e|%|/) 
6330 6 '/K=/'(v330^5|%|/)
6330 6 '/K=/'(v330^6|%|/)
6330 6 '/K=/'(v330^7|%|/) 
6922 6 '/K=/'(v922^5|%|/) 
6922 6 '/K=/'(v922^6|%|/) 
6922 6 '/K=/'(v330^7|%|/) 
6606 8 MHL,'/K=/'(v606|%|/) 
6607 8 MHL,'/K=/'(v607|%|/) 
6610 8 MHL,'/K=/'(v610|%|/) 
6965 8 MHL,'/K=/'(v965|%|/) 
6330 8 MHL,'/K=/'(v330^5,|%|d330/) 
6330 8 MHL,'/K=/'(v330^6,|%|d330/) 
6330 8 MHL,'/K=/'(v330^7,|%|d330/) 
6922 8 MHL,'/K=/'(v922^5,|%|d922/) 
6922 8 MHL,'/K=/'(v922^6,|%|d922/) 
6922 8 MHL,'/K=/'(v922^7,|%|d922/) 
6481 8 MHL,'/K=/'(v481^5,|%|d481/) 
6481 8 MHL,'/K=/'(v481^6,|%|d481/) 
6481 8 MHL,'/K=/'(v481^7,|%|d481/) 
6488 8 MHL,'/K=/'(v488^5,|%|d488/) 
6488 8 MHL,'/K=/'(v488^6,|%|d488/) 
6488 8 MHL,'/K=/'(v488^7,|%|d488/) 
/*IBIS_ID
10 0 (|B=|d10^a,&unifor('E1'v10^a,|%|d10)/)/(|B=|d10^z,&unifor('E1'v10^z,|(���������)|d10^z,|%|d10)/)/if v10^a:v461^i then else (|B=|v461^i,|%|d461/) fi,if v10^z:v461^1 then else (|B=|v461^1|(���������)|,|%|d461/) fi 
10 0 (|HI=|d10^a,&uf(|+9I?-?##|v10^a)/)
11 0 (|B=|v11^a,|%|d11/)/if v11^a:v461^j then else"B="v461^j fi 
19 0 (|B=|d19,v19^a*2| |,v19^b,|%|d19/) 
903 0 MHU,"I="v903/(|II=|v463^w,|%|d463/)/(|I470=|v470^i,|%|d470/)/if v920:'NJ' then(if p(v423^h)then|I=|v423^H,|/|d423,&unifor(|Av934#1|d423),|/|v423^n fi/),/if v936:'/' then 'I='v933,"/"v934,"/"v935,'/'&unifor('G0/'v936)fi fi/ 
903 0 mhu,(if v600^w:'VS' then else |I600=|v600^W fi,|%|d600/)/
933 0 MHU,if p(v933) then if v920:'NJ' then"I933="v933"/"/(|I933=|v423^H,|%|d423/) else "I933="v903 fi fi 
931 0 mhl,if v920:'NJ'then(|I=|v931^2/),(|I=|v931^3/),(|I=|v931^4/),(|I=|v904^a/),(|I=|v931^a/) fi 
930 0 mhl,if v920:'NJ'then (|I=|v930^a/),(if p(v930)then if p(v930^a)then if v930^2<>''then 'I='&unifor('Av933#1'),|/|v930^0,|/|v930^t,|/|v930^2,fi else 'I='&unifor('Av933#1'),|/|v930^0,|/|v930^t,|/|v930^1,/if v930^2<>''then 'I='&unifor('Av933#1'),|/|v930^0,|/|v930^t,|/|v930^2,fi fi fi/)fi  
1 0 "ID="v1/v2
/*IBIS_KOD
903 0 "vrl="v920/(|c=|v102|%|/)/(/|j=|v101|%|)/
900 0 if 'ASP AUNTD':v920 then'V=AS'fi/if v920:'AUNTD' then'V=UD'fi/if v920:'spec' and p(v933) then 'V=NJ_SPEC'v900^b.2 else "V="v900^b.2 fi/if a(v900)then if 'ab 04':v110^b then'V=02'fi/if v110^b:'c'then'V=01'fi/if v920:'nj' then"V="v920/"V=11"d922 fi/if v920='SZPRF'then'V='v920 fi fi/if v920:'musp' then 'V='v920 fi/
900 0 if '0305':v900^b.2 or '0407':v900^b.2 and a(v933) then if 'a1 b': v900^t or a(v900^t) then'V=KN'fi fi 
900 0 &unifor("K900i.mnu|"v900^t)
110 0 &unifor("K900i.mnu|"v110^t) 
900 0 "hd="v900^c/"hd="v900^2/"hd="v900^3/"hd="v900^4/"hd="v900^5/"hd="v900^6
900 0 "hd=454"d454/"hd=481"d481/if a(v900^c) then "hd=d2"d470 fi/ 
900 0 "cn="v900^x/"cn="v900^y/"cn="v900^9/ 
900 0 "hd="v110^g/"hd="v110^k/"hd="v110^L
900 0 if v900:'j02' then else if p(v691) and p(v951^K) then 'hd=j02' fi fi 
900 0 if v900^c:'j' then 'uchl='v900^c fi/
900 0 if v900^2:'j' then 'uchl='v900^2 fi/
900 0 if v900^3:'j' then 'uchl='v900^3 fi/
900 0 if v900^4:'j' then 'uchl='v900^4 fi/
900 0 if v900^5:'j' then 'uchl='v900^5 fi/
900 0 if v900^6:'j' then 'uchl='v900^6 fi/
215 0 MHL,(if p(v215) then if &unifor('Knosfst.mnu|'v215^1)<>''then'N='&unifor('Knosfst.mnu|'v215^1) fi/if &unifor('Knosfst.mnu|'v215^2)<>''then'N='&unifor('Knosfst.mnu|'v215^2) fi fi/) 
904 0 (if p(v904^c) then if &unifor('Knosfst.mnu|'v904^c)<>''then'N='&unifor('Knosfst.mnu|'v904^c) fi fi/) 
993 0 (if p(v993) then if &unifor('Knosfst.mnu|'v993^a)<>''then'N='&unifor('Knosfst.mnu|'v993^a) fi fi/) 
910 0 if v910:'^a7'then'V=DEL',if v910:'^k'then'K'else if 'ASP AUNTD':v920 then 'A' fi fi fi,if p(v1909)and a(v909)and v920='J'then 'V=DELJ'fi
951 0 (|V=EXT%|d951/) 
1251 0 (|MPR=|v125^e/),(|MPR=|v125^1/),(|MPR=|v125^3/)
230 0 if v900^t:'L' then else "V=ZL"d230 fi/
/*IBIS_EX
481 0 MHL,(if p(v481^j) then |IN=|v481^J,if p(v481) then/|INK=|d481^J,if f(val(v481^J),0,0)=v481^J then f(val(v481^J),10,0) else if val(v481^J)=0 then v481^J else if v481^J.1='0'or val(v481^J.1)>0 then if v481^J:'-'and &unifor('G1-'v481^J)<>''then f(val(&unifor('G0-'v481^J)),10,0),&unifor('G1-'v481^J) else if v481^J:'/'and &unifor('G1/'v481^J)<>''then f(val(&unifor('G0/'v481^J)),10,0),&unifor('G1/'v481^J) else if &unifor('G1$'v481^J)<>''then f(val(&unifor('G0$'v481^J)),10,0),&unifor('G1$'v481^J) fi fi fi else if &unifor('G1#'v481^J)<>''then &unifor('G0#'v481^J),f(val(&unifor('G1#'v481^J)),10,0),if f(val(&unifor('G1#'v481^J)),0,0)=&unifor('G1#'v481^J) then else if v481^J:'-'then &unifor('G1-',&unifor('G1#'v481^J)) fi fi fi fi fi fi fi,|%|d481 fi/) 
910 0 mhl,if v920='NJ'then if v910^a:'6'then'INS='v903 fi fi
910 0 MHL,(if p(v910) then if v910^a:'4'then else if v910^a:'6' and a(v910^w) then |INS=|v910^h else |IN=|v910^h fi fi fi,|%|d910/)
910 0 MHL,if v920='J'or v920='NJ'or v920='NJP'then else (if p(v910) then if v910^a:'4'then else if v910^a:'6' and a(v910^w) then |INS=|v910^b else |IN=|v910^b fi fi fi,|%|d910/) fi/
910 0 if v920='J'or v920='NJ'or v920='NJP'then else (if p(v910) then if v910^a:'6' and a(v910^w) then |INSK=|d910^b else |INK=|d910^b fi,if f(val(v910^b),0,0)=v910^b then f(val(v910^b),10,0) else if v910^b.1='0' then v910^b else if val(v910^b.1)>0 then if v910^b:'-' then f(val(&uf('G0-'v910^b)),10,0),'-',&uf('G2-'&uf('G2-'v910^b)) else if v910^b:'/' then f(val(&uf('G0/'v910^b)),10,0),'/',&uf('G2/'&uf('G2/'v910^b)) else if f(val(&uf('G1#'v910^b)),0,0) <> s(&uf('G1#'v910^b)) then f(val(&uf('G0$'v910^b)),10,0),&uf('G1$'&uf('G1#'v910^b)) fi fi fi else if val(v910^b.1)=0 and (not(v910^b.1='0')) then &uf('G0#'v910^b),if v910^b:'-' then if &uf('G0#'v910^b):'-' then f(val(&uf('G2-'v910^b)),10,0) else f(val(&uf('G2$'&uf('G0-'v910^b))),10,0),&uf('G1-'v910^b) fi else if v910^b:'/' then if &uf('G0#'v910^b):'/' then f(val(&uf('G2/'v910^b)),10,0) else f(val(&uf('G2$'&uf('G0/'v910^b))),10,0),&uf('G1/'v910^b) fi else f(val(&uf('G1#'v910^b)),10,0),if f(val(&uf('G1#'v910^b)),0,0) <> s(&uf('G1#'v910^b)) then if val(&uf('G1#'v910^b))>0 then &uf('G1$'&uf('G1#'v910^b)) fi fi fi fi fi fi fi fi fi,|%|d910/) fi/
910 0 mhl,(|NKSU=|v910^u/|NA=|v910^y/if p(v910^y)then |NAS=|v910^u*2.2|-|,v910^y|-| fi/|Coll=|v910^q/|NKS2=|v910^v/|NAP=|v910^w,|%|d910/)
910 0 MHL,(if p(v910) then if '2 6 ':v910^a then else |MHR=|v910^d/|KP=|v910^f fi,|%|d910 fi/)
910 0 (if p(v910)then if v910^A:'4' then |EXU=|v910^H,if &uf('Av920#1'):'NJ' then if v910^h=''then 'EXU='d933,ref(L('I='&uf('Av933#1')),v200^a,". "v923^h,"."v923^i,". "v923^k,"."v923^l,". "v923^m,"."v923^n)fi else/|EXU=|v910^b,if s(v910^h,v910^b)=''then 'EXU=',&uf('Av200^a#1'),if &uf('Av200^a#1')=''then &uf('Av461^c#1')fi fi, fi,fi,fi,|%|d910/)
940 0 MHL,(if p(v940) then if 'C U ':v940^a or v940^a:'6' and p(v940^w) then |NKS2=|v940^v/|NAP=|v940^w fi fi,|%|d940/)
940 0 (if p(v940) then if 'C U ':v940^a then |INS=|v940^b fi fi,|%|d940/)
940 0 (if p(v940) then if 'C U ':v940^a then |INSK=|d940^b,if f(val(v940^b),0,0)=v940^b then f(val(v940^b),10,0) else if v940^b.1='0' then v940^b else if val(v940^b.1)>0 then if v940^b:'-' then f(val(&uf('G0-'v940^b)),10,0),'-',&uf('G2-'&uf('G2-'v940^b)) else if v940^b:'/' then f(val(&uf('G0/'v940^b)),10,0),'/',&uf('G2/'&uf('G2/'v940^b)) else f(val(&uf('G0$'v940^b)),10,0) if f(val(&uf('G1#'v940^b)),0,0) <> s(&uf('G1#'v940^b)) then &uf('G1$'&uf('G1#'v940^b)) fi fi fi else if val(v940^b.1)=0 and (not(v940^b.1='0')) then &uf('G0#'v940^b),if v940^b:'-' then if &uf('G0#'v940^b):'-' then f(val(&uf('G2-'v940^b)),10,0) else f(val(&uf('G2$'&uf('G0-'v940^b))),10,0),&uf('G1-'v940^b) fi else if v940^b:'/' then if &uf('G0#'v940^b):'/' then f(val(&uf('G2/'v940^b)),10,0) else f(val(&uf('G2$'&uf('G0/'v940^b))),10,0),&uf('G1/'v940^b) fi else f(val(&uf('G1#'v940^b)),10,0),if f(val(&uf('G1#'v940^b)),0,0) <> s(&uf('G1#'v940^b)) then if val(&uf('G1#'v940^b))>0 then &uf('G1$'&uf('G1#'v940^b)) fi fi fi fi fi fi fi fi fi fi,|%|d940/)/
/*IBIS_KO
6911 0 MHL,(if p(v691) then if p(v691^w) and a(v691^u) then if s(v691^d,v691^i)<>''then'VUZD=',v691^d,if a(v691^d) then v691^i fi,' - 'v691^g,| ��� |n691^g fi fi,|%|d691/) 
691 0 MHL,(if p(v691) then |NUPL=|v691^u/|NDUN=|v691^w/|FAK=|v691^a/|FIL=|v691^L/|KAFV=|v691^h/|NAPR=|v691^N/|SPEC=|v691^C/|KAFCH=|v691^B/|DISC=|v691^D,if a(v691^D) then |DISC=|v691^i fi/|CIKLD=|v691^s/|KOMP=|v691^k/|VO=|v691^v/|TL=|v691^g/|FO=|v691^o fi,|%|d691/)
691 0 MHL,(if p(v691) then |SEM=|v691^f/if s(v691^U,v691^w)<>''then if a(v691^u) then|NDUNS=|v691^w fi,'-S'v691^f/,if a(v691^u) then|NDUNSS=|v691^w fi,'-S'f(val(v691^f),2,0)/if &unifor('Kkurs.mnu|'v691^f)<>''then'KURS='&unifor('Kkurs.mnu|'v691^f)/,if a(v691^u)then|NDUNK=|v691^w fi,'-K',&unifor('Kkurs.mnu|'v691^f) fi fi fi,|%|d691/) 
691 0 MHL,(|IDD=|v691^i,|%|d691^I/)/(|GR=|v691^R,|%|d691^R/)
691 0 MHL,(if p(v691) then 'DF='v691^I,'-S'v691^f fi/)/(if p(v691) then 'DFS='v691^I,'-S'v691^f,if &uf('KsemV.mnu|'v691^f)<>'' then '-VS' else '-OS' fi fi/)
61 0 MHL,(|TL=Pot. |v61/) /(|PL=|v61/)  
692 0 (if p(v692) then if p(v692^B) then 'SVKO=',v692^B,|-|v692^C fi fi/) 
691 0 MHL,(if p(v691) then 'AF='v691^a,'-S'v691^f/'CF='v691^c,'-S'v691^f fi/)
691 0 MHL, (if p(v691) then|VUZ= ���-���-����:|v691^a|-|,v691^f|-|,v691^c/|VUZ=���: |v691^b/|VUZ=����: |v691^c/if s(v691^d,v691^i)<>''then'VUZ=����: ',v691^d,if p(v691^i)then|(|d691^d,v691^i,|)|d691^d fi fi fi/) 
230 0 (|V=ZU|d951^K/)/if s(v900^C' 'v900^2' 'v900^3' 'v900^4' 'v900^5' 'v900^6): 'j02' then 'V=ZU' fi
/*IBIS_VIXD
7 0 MHL,if v920='J'then else"g="v934,/(if v210^d.1='['then 'g=',&unifor('G0]'&unifor(|G1#|v210^d)),' [ ]',&unifor('G0#'&unifor(|G2[|v210^d)),else |g=|v210^d fi,| |v210^5/),if v210^h<>''then (if p(v210^h)then if v210^h.1='['then 'g=',&unifor('G0]'&unifor(|G1#|v210^h)),' [ ]',&unifor('G0#'&unifor(|G2[|v210^h)),else |g=|v210^h fi,|\���.\|d210^h,fi/)fi,if a(v210^d)then(if v461^h.1='['then 'g=',&unifor('G0]'&unifor(|G1#|v461^h)),' [ ]',&unifor('G0#'&unifor(|G2[|v461^h)),else |g=|v461^hfi,| |v461^5/)fi,(if v463^j.1='['then 'g=',&unifor('G0]'&unifor(|G1#|v463^j*1)),' [ ]',&unifor('G0#'&unifor(|G2[|v463^j)),else |g=|v463^jfi/)fi 
210 0 MHL,&uf('+7W7#'),&uf('+7W8#'),(if p(v210^c) then'O=',&unifor(|9|v210^c,|(|v210^a,| ; |v210^x,| ; |v210^y,|)|d210^a,|\|v210^6|\|)fi,|%|d210/),(|MI=|d210^a,if v210^a.1='['then &unifor(|G0]|v210^a*1),' [ ]',else v210^a fi/|MI=|d210^x,if v210^x.1='['then &unifor(|G0]|v210^x*1),' [ ]',else v210^x fi/if v210^y:';' then else |MI=|d210^y,if v210^y.1='['then &unifor(|G0]|v210^y*1),' [ ]',else v210^y fi fi/)/if v210^y:';' then &uf('+7W7#'),&uf('+7W8#'),if v210^y:' ; ' then &uf('+7W7#'(if v210^y:' ; 'then v210^y| ; | fi)),&uf('+7W8#'(&uf('1*R ; ?g7#1')/)) else if v210^y:'; ' then &uf('+7W7#'(if v210^y:'; 'then v210^y|; | fi)),&uf('+7W8#'(&uf('1*R; ?g7#1')/)) fi fi,if &uf('Ag8.1#1')='[' then (if p(g8) then 'MI='if g8.1='[' then g8*1' [ ]' else &uf('G0]'g8),' [ ]' fi fi/) else (|MI=|g8/) fi fi,
211 0 MHL,(if p(v210^g) then'OT=',&unifor(|9|v210^g,|(|v210^1,|)|d210^1,)fi/|MI=|d210^1,if v210^1.1='['then &unifor(|G0]|v210^1*1),' [ ]',else v210^1fi/|%|d210/) 
461 0 MHL,(if p(v461^g) then'O=',&unifor(|9|v461^g,|(|v461^d|)|,|\|v461^6|\|)fi,|%|d461/),
461 0 MHL,if v461^d<>'' then &uf('+7W6#'),&uf('+7U6#'(if p(v461) then &uf('G0;'v461^d)/if v461^d:';' then if &uf('G2;'v461^d):';' then &uf('G0;'&uf('G2;'v461^d))/&uf('G0;'&uf('G2;'&uf('G2;'v461^d))) else &uf('G2;'v461^d) fi fi fi/)),(if g6.2:' [' then 'MI='&uf('G0]'g6*2),'[]' else if g6.1='['then 'MI='&uf('G0]'g6*1),'[]' else if g6.1=' 'then 'MI='&uf('G0]'g6*1) else |MI=|g6 fi fi fi/) fi
463 0 mhl,(if p(v463^g) then'O=',&unifor(|9|v463^g,|(|v463^d|)|)fi/&uf('+7W463#'if v463^d.1='['then'1'fi),if v463^d:';'then'MI=', if v463^d.1='['then &uf('G0 '&uf('G0;'v463^d*1)),'[ ]',else &uf('G0 '&uf('G0;'v463^d)) fi'%'/'MI=', if &uf('G2;'v463^d):';' then &uf('G0 '&uf('G0;'&uf('G2 '&uf('G2;'v463^d)))),if g463='1'then'[ ]'fi'%'/'MI=',&unifor('G2 '&uf('G2;'&uf('G2;'&uf('G0]'v463^d)))),if g463='1'then'[ ]'fi'%' else &uf('G2 '&uf('G2;'&uf('G0]'v463^d))),if g463='1'then'[ ]'fi'%'/ fi else |MI=|d463^d,if v463^d.1='['then &uf('G0]'v463^d*1),'[ ]', else v463^d fi,fi/)
481 0 MHL,(if p(v481^g) then'O=',&unifor(|9|v481^g,|(|v481^d|)|) fi,|%|d481/)
488 0 MHL,(if p(v488^g) then'O=',&unifor(|9|v488^g,|(|v488^d|)|) fi,|%|d488/) 
/*IBIS_OTHER
101 0 (if p(v101)then 'jaz=',&uf(|Kjz.mnu\|v101)fi/)
102 0 (if p(v102)then 'cna=',&uf(|Kstr.mnu\|v102)fi/)
929 0 MHL,(|RK316=|v929,|%|d929/),if a(v929) then (|RK316=|v316^b,|%|d316/)/(|RK316=|v316^c,|%|d316/) fi 
8 0 MHL,if v920='J' then (|jr=|v909^q|%|/)/(|jrs=|v1909^q|%|/)fi/ 
907 0 if s(v910^c,v907^a)<>''then'DP='&unifor('Av907^a#1'),if a(v907^a)then &unifor('Av910^c#1')fi/if v920='J' then else (|DR=|v910^c/) fi fi 
902 0 (|X=|v902^a/) 
690 0 (if p(v690) then if v690^l*1.1='.'or v690^l*1=''then|SU= |v690^l else |SU=|v690^l fi fi/)/(if p(v330) then if v330^l*1.1='.'or v330^l*1=''then|SU= |v330^l else |SU=|v330^l fi fi/)/if v920:'NJ' then (if p(v922) then if v922^l*1.1='.'or v922^l*1=''then|SU= |v922^l else |SU=|v922^l fi fi/) fi
239 0 (|ST=|v239|%|/)
230 0 if p(v230) then if a(v239) then (if &unifor('1*R; ?v230^d#1')<>''then/'ST='&unifor('1*R; ?v230^d#1') fi,|%|d230)/(if &unifor('1*R; ?v230^d#2')<>''then/'ST='&unifor('1*R; ?v230^d#2') fi,|%|d230)/(if &unifor('1*R; ?v230^d#3')<>''then/'ST='&unifor('1*R; ?v230^d#3') fi,|%|d230) fi fi
39 0 MHL,"RD=EX"d398/"RD=PA"d395/"RD=PV"d396/"RD=SH"d399/"RD=TI"d397/"RD=AF"d391/"RD=PI"d481/"RD=OK"d316/"RD=PK"d317/"RD=DK"d318 
907 0 if v920='J' then else if &unifor('Korg.mnu|8'):'1'then (if v907^b<>''then|TH=|v907^b,if v907^c:'���'then|-|v907^c fi,|-|v907^a fi/if v907^a<>''then|TH=|v907^a,|-|v907^b fi,|%|d907/) fi fi 
910 0 if &unifor('Korg.mnu|7'):'1'or &unifor('IPRIVATE,PROVFOND,')='1'or &unifor('IMAIN,PROVFOND,')='1'then (if p(v910)then if v910^a:'6' and a(v910^w) or '2 7':v910^a then else if &unifor('Av920#1')='NJ'or &unifor('Av920#1')='NJP'then |INP=|v910^h,if p(v910^h) then|�|d910^s,|(|v910^0,if p(v910^s)then| �� |v910^1 fi,|)|d910^0,if 'C U':v910^a and p(v910^s) and val(v910^1)>val(v910^0)then /|INP=|v910^h|(|,f(val(v910^1)-val(v910^0),0,0),if p(v910^s)then| �� |v910^1fi,|)|d910^h fi fi else |INP=|v910^b,if p(v910^b) then|�|d910^s,|(|v910^0,if p(v910^s)then| �� |v910^1fi,|)|d910^0if 'C U':v910^a and p(v910^s) and val(v910^1)>val(v910^0)then /|INP=|v910^b|(|,f(val(v910^1)-val(v910^0),0,0),if p(v910^s)then| �� |v910^1fi,|)|d910^b fi fi/|INP=|v910^h,if p(v910^h) then|�|d910^s,|(|v910^0|)|,if 'C U':v910^a and p(v910^s) and val(v910^1)>val(v910^0)then /|INP=|v910^h|(|,f(val(v910^1)-val(v910^0),0,0),if p(v910^s)then| �� |v910^1fi,|)|d910^h fi fi fi/if a(v910^s) then'INP=�� ��������� 'v910^d fi/if p(v910^!) then'INP=�� �� ����� ('v910^!')'fi/|INP=��������� |d910^s,v910^s*6.2|.|,v910^s*4.2|.|,v910^s.4,fi fi,|%|d910/)fi
80 0 if &unifor('IMAIN,ATHRSAK,')='1'then (if p(v606) then '?',if v606:'^a' and v606^b='' and v606^G='' and v606^H='' and v606^9='' and v606^a*27=''then v606^a else v606^a.10, &unifor(|+B|v606^a*10)fi,if v606^d='' and v606^b*10='' and v606^b<>''then v606^b else v606^b.1,&unifor(|+B|v606^B*1) fi,&unifor(|+B|v606^c),&unifor(|+B|v606^d),&unifor(|+B|v606^G),&unifor(|+B|v606^E),&unifor(|+B|v606^O),&unifor(|B|v606^H),&unifor(|+B|v606^9) fi/) fi 
80 0 if &unifor('IMAIN,ATHRSAK,')='1'then (if p(v607) then '?',if v607:'^a' and v607^b='' and v607^G='' and v607^H='' and v607^9='' and v607^a*27=''then v607^a else v607^a.10, &unifor(|+B|v607^a*10)fi,if v607^d='' and v607^b*10='' and v607^b<>''then v607^b else v607^b.1,&unifor(|+B|v607^B*1) fi,&unifor(|+B|v607^c),&unifor(|+B|v607^d),&unifor(|+B|v607^G),&unifor(|+B|v607^E),&unifor(|+B|v607^O),&unifor(|B|v607^H),&unifor(|+B|v607^9) fi/) fi 
907 0 if v920='J' then &uf('+7W1#'f(rmin((v907^a.6|;|/)),0,0)/),&uf('+7W2#'g1.4),&uf('+7W3#'g1*4.2)/"DNJ="g1/if val(g3)<4 then /'DNJ='g2'1/3'/'DNJ='g2'1-4/1'/'DNJ='g2'1/1'/'DNJ='g2'1/0' fi,if 3< val(g3) and val(g3)<7  then /'DNJ='g2'1-4/2'/'DNJ='g2'1/1'/'DNJ='g2'1/0'/'DNJ='g2'1/3' fi,if 6< val(g3) and val(g3)<10 then /'DNJ='g2'1-4/3'/'DNJ='g2'1/2'/'DNJ='g2'1/0'/'DNJ='g2'1/3' fi,if 9< val(g3) then /'DNJ='g2'1-4/4'/'DNJ='g2'1/2'/'DNJ='g2'1/0' fi fi
36 0 MHL,(if p(v36) then |NI=|v36^p,|%|d36 fi/)
2222 0 &unifor('+1W1001#',(if p(v901)then if v901^v<>''then  if &unifor('3')>s(f(val(v901^q)+val(v901^v),0,0),'0101')then v901^q,| |v901^b,| |v901^d|;|fi fi fi/)),(if p(v909)then if &unifor('+1R1001'):s(v909^q,| |v909^k,| |v909^d|;|)then 'ZVH=',&unifor('Av903#1'),| |,v909^q,| |v909^k,| |v909^d|;|fi fi/)
951 0 mhl,(if p(v951) then if p(v951^I) then |TEK=|v951^I|%| else if p(v951^a) then |TEK=|v951^a|%| fi fi fi/)
1111 0 (if p(v463^h) then 'NM=',f(val(v463^h),0,0) fi/)
1111 0 (if p(v463^v) then 'NV=',f(val(v463^v),0,0) fi/)
1111 0 (|IA=|v963^I/)
390 0 MHL,(if p(v390) then if p(v390^x) then|TSIT=|d390^x,if p(v390^9) then if v390^9:'1' then v390^x else &unifor('E'v390^9,v390^x),|, |v390^?,if a(v390^?) then if &unifor('F'v390^9,v390^x)<>'' then ', 'if &unifor('F'v390^9,v390^x):'. ' then &unifor('F'v390^9,v390^x) else if &unifor('F'v390^9,v390^x):'.'then &unifor('G0.'&unifor('F'v390^9,v390^x)),'. '&unifor('G2.'&unifor('F'v390^9,v390^x)) else &unifor('F'v390^9,v390^x) fi fi fi fi fi else if v390^x:',' then &unifor('G0,'v390^x),else &unifor('G0 'v390^x) fi,|, |v390^?,if a(v390^?) then if &unifor('G2 'v390^x):'. ' then ', '&unifor('G2 'v390^x) else if &unifor('G2 'v390^x):'.'then ', ' &unifor('G0.'&unifor('G2 'v390^x)),'. '&unifor('G2.'&unifor('G2 'v390^x)) fi fi fi fi fi ,if p(v390^2) then/|TSIT=|d390^2,if p(v390^<) then if v390^<:'1' then v390^2 else &unifor('E'v390^<,v390^2),|, |v390^,,if a(v390^,) then if &unifor('F'v390^<,v390^2)<>'' then ', 'if &unifor('F'v390^<,v390^2):'. ' then &unifor('F'v390^<,v390^2) else if &unifor('F'v390^<,v390^2):'.'then &unifor('G0.'&unifor('F'v390^<,v390^2)),'. '&unifor('G2.'&unifor('F'v390^<,v390^2)) else &unifor('F'v390^<,v390^2) fi fi fi fi fi else if v390^2:',' then &unifor('G0,'v390^2),else &unifor('G0 'v390^2) fi,|, |v390^,,if a(v390^,) then if &unifor('G2 'v390^2):'. ' then ', '&unifor('G2 'v390^2) else if &unifor('G2 'v390^2):'.'then ', ' &unifor('G0.'&unifor('G2 'v390^2)),'. '&unifor('G2.'&unifor('G2 'v390^2)) fi fi fi fi fi ,if p(v390^3) then/|TSIT=|d390^3,if p(v390^>) then if v390^>:'1' then v390^3 else &unifor('E'v390^>,v390^3),|, |v390^;,if a(v390^;) then if &unifor('F'v390^>,v390^3)<>'' then ', 'if &unifor('F'v390^>,v390^3):'. ' then &unifor('F'v390^>,v390^3) else if &unifor('F'v390^>,v390^3):'.'then &unifor('G0.'&unifor('F'v390^>,v390^3)),'. '&unifor('G2.'&unifor('F'v390^>,v390^3)) else &unifor('F'v390^>,v390^3) fi fi fi fi fi else if v390^3:',' then &unifor('G0,'v390^3),else &unifor('G0 'v390^3) fi,|, |v390^;,if a(v390^;) then if &unifor('G2 'v390^3):'. ' then ', '&unifor('G2 'v390^3) else if &unifor('G2 'v390^3):'.'then ', ' &unifor('G0.'&unifor('G2 'v390^3)),'. '&unifor('G2.'&unifor('G2 'v390^3)) fi fi fi fi fi ,fi,|%|d390/)
901 0 if p(v901^q)or p(v938^q) then &uf('+7W1#'(|PP=|v901^q/|PP=|v938^q/)),&uf('+1G1'),fi 
/*IBIS_DEB
1111 8 MHL,'/',&uf('IMAIN,DebilPrefix,DS='),'/',if &unifor('IMAIN,DBSCH,')='1'then &unifor('+0'),/mhl,&unifor("K900t.mnu|"v900^t),/&unifor("Kvd.mnu|"v900^B.2),/if '03040507':v900^b.2 and a(v982) then if 'a1 b':v900^t or a(v900^t) then'�����'fi fi,/&unifor("K110b.mnu|"v110^B.2),/"����������� ����������� ��������"d981,/&unifor("Khd.mnu\"v900^C),/&unifor("Khd.mnu\"v900^2),/&unifor("Khd.mnu\"v900^3),/&unifor("Khd.mnu\"v900^4),/&unifor("Khd.mnu\"v900^5),/&unifor("Khd.mnu\"v900^6),/&unifor("Kstr.mnu\"v102),(/&unifor(|Kjz.mnu\|v101)),if v900^b:'o'or p(v102) and &unifor('Korg.mnu|1')=v102 then'�������������'fi,/if v900^b:'z'or p(v102) and &unifor('Korg.mnu|1')<>v102 then '����������� ����������'fi fi/ 
/*IBIS_MESH
995 8 '/K=/',(if v995^A<>'' then v995^A else &uf('DMESH,!R=',v995^K,'!,v2') fi,/)
995 8 '/K=/',(if v995^B<>'' then v995^B else &uf('DMESH,!R=',v995^K,'!,v1') fi,/)
996 8 '/K=/',(if v996^A<>'' then v996^A else &uf('DMESH,!R=',v996^K,'!,v2') fi,/)
996 8 '/K=/',(if v996^B<>'' then v996^B else &uf('DMESH,!R=',v996^K,'!,v1') fi,/)
995 0 (if p(v995) then 'S=',if v995^A<>'' then v995^A else &uf('DMESH,!R=',v995^K,'!,v2') fi,/ fi)
995 0 (if p(v995) then 'S=',if v995^B<>'' then v995^B else &uf('DMESH,!R=',v995^K,'!,v1') fi,/ fi)
996 0 (if p(v996) then 'S=',if v996^A<>'' then v996^A else &uf('DMESH,!R=',v996^K,'!,v2') fi,/ fi)
996 0 (if p(v996) then 'S=',if v996^B<>'' then v996^B else &uf('DMESH,!R=',v996^K,'!,v1') fi,/ fi)
996 6 '/MM=/',(v996^m,|%|d996/)
995 6 '/MM=/',(v995^m,|%|d995/)
996 0 (|MK=|v996^k|%|/)
995 0 (|MK=|v995^k|%|/)
/*IBIS_TITP
200 0 MHL,if v200^u:'1'then else if p(v200^a) then'TP=',&unifor("9"v200^a,(|. |v923^h,|.|v923^i,|. |v923^k,|.|v923^l,|. |v923^m,|.|v923^n)) fi,if v920='J'then ' \����.\' else if p(v463)then ' \������.��������\' else "/"v200^f,"; "v200^g,","v210^d,if a(v210^d) then|, |v461^h fi,".-"|; |+v215^a,v215^1,if p(v215^a) and a(v215^1) then &unifor('Korg.mnu|4')'.' fi fi fi fi
200 0 MHL,if p(v982) then if v200^a:&unifor('Av982^9#1') or v200^u:'1'then else 'TP=',&unifor('Av982^0#1')," "d982^0,&unifor('Av982^9#1')," "d982^9 &unifor("9"v200^a,(|. |v923^h,|.|v923^i,|. |v923^k,|.|v923^l,|. |v923^m,|.|v923^n)) fi fi / 
510 0 MHL,(if p(v510) then |TP=|d510^d,&unifor(|9|v510^d),' \������. ����.',if &unifor('Av920#1')='J'then ' - ����.\' else if &unifor('Av463#1')<>''then ' - ������. ��������\' else'\' fi fi fi,|%|d510/)
922 0 MHL,(if p(v922) then |TP=|d922^c,&unifor(|9|v922^c),' \��. �� ',if &unifor('Av920#1'):'NJ'then'���. ����.\'else'��������\'fi fi,|%|d922/)
9227 0 MHL,(if p(v922) then |TP=|d922^d,&unifor(|9|v922^d),' \������. ����.' fi,|%|d922/) 
9228 0 MHL,(if p(v922) then |TP=|d922^p,&unifor(|9|v922^p),' \������. ����.' fi,|%|d922/) 
9229 0 MHL,(if p(v922) then |TP=|d922^r,&unifor(|9|v922^r),' \������. ����.' fi,|%|d922/) 
9251 0 MHL,(if p(v925^a) then if v925^u:'1'and &unifor('Av461^c#1')<>''then'TP=',&unifor('9'&unifor('Av461^c#1'),if &unifor('Av461^f#1')<>''then' / '&unifor('Av461^f#1') fi,|;|v925^v,|:|v925^a) else /'TP='&unifor('9'v925^a) fi,' \������ ��� � ����� �����\' fi,|%|d925/)/
9252 0 MHL,(if p(v925^b) then if v925^u:'1'and &unifor('Av461^c#1')<>''then'TP=',&unifor('9'&unifor('Av461^c#1'),if &unifor('Av461^f#1')<>''then' / '&unifor('Av461^f#1') fi,|;|v925^v,|:|v925^b) else /'TP='&unifor('9'v925^b) fi,' \������ ��� � ����� �����\' fi,|%|d925/)/
9253 0 MHL,(if p(v925^c) then if v925^u:'1'and &unifor('Av461^c#1')<>''then'TP=',&unifor('9'&unifor('Av461^c#1'),if &unifor('Av461^f#1')<>''then' / '&unifor('Av461^f#1') fi,|;|v925^v,|:|v925^c) else /'TP='&unifor('9'v925^c) fi,' \������ ��� � ����� �����\' fi,|%|d925/)/
925 0 MHL, (if p(v925)   then if a(v925^u) and &unifor('Av461^c#1')<>''then'TP=',&unifor('9'&unifor('Av461^c#1'),if &unifor('Av461^u#1'):'1'then if s(&unifor('Av461^x#1'),&unifor('Av461^b#1'))<>''then'/'&unifor('Av461^x#1'),&unifor('Av461^b#1') fi fi,|;|v925^v),' \������ ��� � ����� �����\' fi fi,|%|d925/)
470 0 MHL,(if p(v470^c) then'TP=',&unifor(|9|v470^c,| (|v470^0|)|) fi,|%|d470/)
923 0 MHL,(if p(v923^i) then if v923^u:'1'then else 'TP=',&unifor(|9|v923^i,|. |v923^l,|. |v923^n) fi,if &unifor('Av920#1')='J'then '\����� ����.\'else if &unifor('Av463#1')<>''then '\������/����� - ������.��������\' else "/"v200^f,";"v200^g,","v210^d,if a(v210^d) then|, |v461^h fi,".-"|; |+v215^a,v215^1,if p(v215^a) and a(v215^1) then &unifor('Korg.mnu|4')'.' fi fi fi fi,|%|d923/)
461 0 MHL,if p(v461^c) then'TP=',&unifor('9'v461^c,(|. |v46^h,if p(v46^i) then|, |v46^i else |. |v46^i fi,|. |v46^k,if p(v46^k) then|, |v46^m else |. |v46^m fi),if v461^u:'1'then|/|v461^x,|/|v461^b fi," ; "v200^v,if v200^u:'1'then":"d200^v,"."n200^v,v200^a,(|. |v923^h,|.|v923^i,|. |v923^k,|.|v923^l,|. |v923^m,|.|v923^n) fi),' \����� ����. ��-���\' fi,|%|d461/
4611 0 MHL,(if p(v461^a) then|TP=|d461^a,&unifor(|9|v461^a),' \������� ������ ����. ��\'fi,|%|d461/)
463 0 MHL,(if p(v463^c) then'TP=',&unifor(|9|v463^c,|/ |v963^b,| \���. ��.\|d463^c) fi,|%|d463/)
423 0 MHL,if v920='J'then (if p(v423) then|TP=|d423^a,&unifor(|9|v423^a),|. |d423^s,v423^v| |,&unifor(|9|v423^s),' \������ � �������\' fi,|%|d423/)fi
423 0 mhl,if v920='J'then (if p(v423^s then |TP=|d423^s,&unifor(|9|v423^s),' \������ � ������� - �����\'fi,|%|d423/)fi
330 0 MHL,(if p(v330) then|TP=|d330^c,&unifor(|9|v330^c),' \��. �� ������.��������\'fi,|%|d330/)
3307 0 MHL,(if p(v330) then|TP=|d330^d,&unifor(|9|v330^d),' \������. ����.' fi,|%|d330/) 
430 0 MHL,(if p(v430) then|TP=|d430^a,&unifor(|9|v430^a),' \������ ����. ����.\'fi,|%|d430/)
454 0 MHL,(if p(v454) then|TP=|d454^a,&unifor(|9|v454^a,|/|v454^b),' \�������� ��������. ���.',if p(v454^u) then ' - ��\' else'\'fi fi,|%|d454)
481 0 MHL,(if p(v481^c) then if v481^u:'1'then else |TP=|d481^c,&unifor(|9|v481^c),if a(v481^z) then |;|v481^v fi,' \������������ ���.\'fi fi,|%|d481/),
481 0 MHL,if s(v481^z)<>''then &uf('+7W46#'(|. |v46^h,if p(v46^i) then|, |v46^i else |. |v46^i fi,|. |v46^k,if p(v46^k) then|, |v46^m else |. |v46^m fi)),(if p(v481^z) then'TP=',&unifor('9'&unifor('Av461^c#1'),&uf('Ag46#1'),if &unifor('Av461^u#1'):'1'then if s(&unifor('Av461^x#1'),&unifor('Av461^b#1'))<>''then'/'&unifor('Av461^x#1'),&unifor('Av461^b#1') fi fi,|;|v481^v,if v481^u:'1'then|:|v481^c fi),' \������������ ���.\'fi,|%|d481/) fi
488 0 MHL,(if s(v488^c,v488^z)<>'' then |TP=|d488,&uf(|9|d488,if v488^u:'1'then v488^z, |;|v488^v |:|d488^c fi v488^c,|. |v488^r,|.|v488^s,|. |v488^k,|.|v488^l,  ' \��������� ���.\',) fi,|%|d488/),
541 0 MHL,if p(v541) then"TP="d541,&unifor("9"v541),' \������� ����.',if v920='J'then ' - ����.\' else if p(v463)then ' - ������.��������\' else'\'fi fi fi
517 0 MHL,(if p(v517) then|TP=|d517^a,&unifor(|9|v517^a),' \�����������\'fi,|%|d517/)
225 0 MHL,(if p(v225^a) then'TP=',&unifor(|9|v225^a,|/|v225^f)' \�����\' fi,|%|d225/)
601 0 MHL,(if p(v601) then|TP=|d601^z,&unifor(|9|v601^z),' \�������� ��� �������\'fi,|%|d601/)/
600 0 MHL,(if p(v600) then|TP=|d600^z,&unifor(|9|v600^z),' \�������� ��� �������\'fi,|%|d600/)/
4601 0 MHL,(if p(v46^a) then|TP=|d46^a,&unifor(|9|v46^a),' \����� - ��\'fi,|%|d46/)/
4602 0 MHL,(if p(v46^l) then|TP=|d46^l,&unifor(|9|v46^l),' \������. ����. -  ��\'fi,|%|d46/)
4603 0 MHL,(if p(v46^c) then|TP=|d46^c,&unifor(|9|v46^c),' \���������� ����. -  ��\'fi,|%|d46/)
/*IBIS_USER
