
using System;
using Gatekeeper.Core;
namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of SecurableObjectDao class.
    /// </summary>
    /// <remarks>
    /// 	<para>
    /// 		<list type="table">
    /// 			<listheader>
    /// 				<description>modified</description>
    /// 				<description>by</description>
    /// 				<description>description</description>
    /// 			</listheader>
    /// 			<item>
    /// 				<description>9/24/2008</description>
    /// 				<description>Chamith Siriwardena</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
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
