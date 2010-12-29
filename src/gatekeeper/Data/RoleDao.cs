using Gatekeeper.Collections;
using System.Collections.Generic;
using Gatekeeper.Core;
using System.Collections;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of RoleDao class.
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
    internal class RoleDao : BaseDao<Role>
    {
		public RoleDao():base(SqlMapper.Instance){}
		
        /// <summary>
        /// Gets all the roles of a specified application by passing applicationId.It returns collection of Rolls.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <returns></returns>
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
        internal RoleCollection Get(Application application)
        {
            return new RoleCollection(
                this.DataMapper.QueryForList<Role>("role-select-by-applicationId", application.Id)
            );
        }
		
        /// <summary>
        /// Gets the role in a specified application by with a specified name.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="name">The name of the role.</para>
        /// <returns></returns>
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
        internal Role Get(Application application, string name)
        {
			Hashtable args = new Hashtable();
			args["ApplicationId"] = application.Id;
			args["Name"] = name;
            return this.DataMapper.QueryForObject<Role>("role-select-by-applicationId-name", args);
        }    
	}
}
