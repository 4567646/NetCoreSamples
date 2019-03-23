using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Core.CodeGenerator.Model
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DatabaseType
    {
        SqlServer,
        MySQL,
        PostgreSQL,
        SQLite,
        InMemory,
        Oracle,
        MariaDB,
        MyCat,
        Firebird,
        DB2,
        Access
    }
}
