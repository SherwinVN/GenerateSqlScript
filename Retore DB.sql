RESTORE DATABASE [TTV_MAS16_AnNinhQuocTe] 
FROM  DISK = N'D:\TTV_AnNinhQuocTe\DB\TTV_MAS_2016_TT200_2019_10_02.Bak' 
WITH  FILE = 1,  
MOVE N'TTV_ACC_APP_Data' 
TO N'D:\TTV_AnNinhQuocTe\DB\TTV_MAS16_AnNinhQuocTe.MDF',  
MOVE N'TTV_ACC_APP_Log' 
TO N'D:\TTV_AnNinhQuocTe\DB\TTV_MAS16_AnNinhQuocTe_log.LOG',  
NOUNLOAD,  REPLACE,  STATS = 10
GO
