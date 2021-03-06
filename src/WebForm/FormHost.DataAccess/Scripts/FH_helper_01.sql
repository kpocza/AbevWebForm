select 
   [Pid]    = p.spid, 
   [Database] = db_name(p.dbid)
	into #runningirmcmdatabases
from master.dbo.sysprocesses p

delete from #runningirmcmdatabases where [Database] NOT IN ('FormHost')


declare pidcursor cursor 
for select pid from #runningirmcmdatabases

open pidcursor 

declare @pid int
declare @killstatement nvarchar(10)

fetch next from pidcursor into @pid
While (@@FETCH_STATUS <> -1)
BEGIN
	print @pid
	set @killstatement = 'KILL ' + cast(@pid as varchar(3))
    exec sp_executesql @killstatement
	
	fetch next from pidcursor into @pid
end

close pidcursor 
deallocate pidcursor 

drop table #runningirmcmdatabases
