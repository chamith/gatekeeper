
using System;
using Gatekeeper.Core;
namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of SecurableObjectDao class.
    /// </summary>
    internal class SecurableObjectDao:BaseDao<SecurableObject>
    {
		internal SecurableObjectDao():base(SqlMapper.Instance){}
		
        internal long GetId(Guid securableObjectGuid)
        {
            return this.DataMapper.QueryForObject<long>("securableObject-select-by-securableObjectGuid", securableObjectGuid);
        }

        internal SecurableObject Get(Guid guid)
        {
            return this.DataMapper.QueryForObject<SecurableObject>("securableObject-select-by-guid", guid);
        }
    }
}
