using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using System.Reflection;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    internal class SqlMapper
    {        
        #region Singleton Implementation of the SqlMapper

        private static volatile ISqlMapper _mapper = null;

        internal static ISqlMapper Instance
        {
            get
            {
                if (_mapper == null)
                {
                    lock (typeof(SqlMapper))
                    {
                        if (_mapper == null) // double-check
                        {
                            _mapper = GatekeeperDataMapperBuilder.Build(MethodBase.GetCurrentMethod().DeclaringType.Namespace);
                        }
                    }
                }

                return _mapper;
            }
        }

        #endregion
    }
}
