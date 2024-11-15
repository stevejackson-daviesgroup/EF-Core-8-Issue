using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EF_Core_8_Issue;

public class QueryLogger : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        if (eventData.Context is DatabaseContext dbContext)
        {
            dbContext.ExecutedCommands.Add(command.CommandText);
        }

        return result;
    }
}