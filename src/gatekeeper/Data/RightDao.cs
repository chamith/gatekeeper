using Gatekeeper.Collections;
using System.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of RightDao class.
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
    internal class RightDao : BaseDao<Right>
    {
		public RightDao():base(SqlMapper.Instance){}
		
        /// <summary>
        /// Gets all the rights of a specified application by passing applicationId,it returns collection of rights.
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
        internal RightCollection Get(Application application)
        {
            return new RightCollection(this.DataMapper.QueryForList<Right>("right-select-by-applicationId", application.Id));
        }

        /// <summary>
        /// Gets all the rights of a specified Role,it returns collection of rights.
        /// </summary>
        /// <param name="role">The role.</param>
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
        internal RightCollection Get(Role role)
        {
            return new RightCollection(this.DataMapper.QueryForList<Right>("right-select-by-roleId", role.Id));
        }
        /// <summary>
        /// Gets colletion of Rights of a specified securableObjectType,it returns right collection.
        /// </summary>
        /// <param name="securableObjectType">Type of the securable object.</param>
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
        internal RightCollection Get(SecurableObjectType securableObjectType)
        {
            return new RightCollection(this.DataMapper.QueryForList<Right>("right-select-by-securableObjectTypeId", securableObjectType.Id));
        }
		
		internal Right Get(Application application, string name)
		{
			Hashtable args = new Hashtable();
			args["ApplicationId"] = application.Id;
			args["Name"] = name;
			return this.DataMapper.QueryForObject<Right>("right-select-by-applicationId-name", args);
		}
    }
}
