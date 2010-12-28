using System;
using System.IO;
using System.Reflection;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper;
namespace Gatekeeper.Core
{
    public class GatekeeperDataMapperBuilder
    {
        public static ISqlMapper Build(string contextName)
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            if (contextName.Length > 0)
                contextName = contextName + ".";

            Stream stream = new EmbeddedResourceHelper().GetEmbeddedFile(Assembly.GetCallingAssembly(), contextName + "sqlmap.config");
            return builder.Configure(stream);
        }

    }
}

