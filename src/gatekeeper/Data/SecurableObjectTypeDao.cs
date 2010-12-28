using Gatekeeper.Collections;
using System.Collections;
using Gatekeeper.Core;

namespace Gatekeeper.Data
{
    /// <summary>
    /// Summary of SecurableObjectTypeDao class.
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
    /// 				<description>9/25/2008</description>
    /// 				<description>Chamith Siriwardena</description>
    /// 				<description>initial code</description>
    /// 			</item>
    /// 		</list>
    /// 	</para>
    /// </remarks>
    internal class SecurableObjectTypeDao : BaseDao<SecurableObjectType>
    {
		internal SecurableObjectTypeDao():base(SqlMapper.Instance){}
        /// <summary>
        /// Gets the securableObjectType of a specified securable object id.
        /// </summary>
        /// <param name="securableObjectId">The securable object id.</param>
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
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        internal SecurableObjectType GetBySecurableObjectId(long securableObjectId)
        {
            return this.DataMapper.QueryForObject<SecurableObjectType>(
                    "securableObjectType-select-by-securableObjectId", securableObjectId);
        }

        /// <summary>
        /// Gets the SecurableObjectType object of a specified application and for a particular securableObjectTypeId.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="securableObjectTypeId">The securable object type id.</param>
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
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        internal SecurableObjectType Get(Application application, long securableObjectTypeId)
        {
            Hashtable args = new Hashtable();
            args["applicationId"] = application.Id;
            args["securableObjectTypeId"] = securableObjectTypeId;
            
            return this.DataMapper.QueryForObject<SecurableObjectType>(
                    "securableObjectType-select", args);
        }

        /// <summary>
        /// Gets all the SecurableObjectType objects of a specified  application by passing applicationId,it returns collection of SecurableObjectTypes.
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
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        internal SecurableObjectTypeCollection Get(Application application)
        {
            return new SecurableObjectTypeCollection(
                this.DataMapper.QueryForList<SecurableObjectType>(
                    "securableObjectType-select-by-applicationId", application.Id)
            );
        }

        /// <summary>
        /// Gets securableObjectType of a specified application and name by passing applicatiOnId and name.
        /// </summary>
        /// <param name="name">The name.</param>
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
        /// 				<description>9/25/2008</description>
        /// 				<description>Chamith Siriwardena</description>
        /// 				<description>initial code</description>
        /// 			</item>
        /// 		</list>
        /// 	</para>
        /// </remarks>
        internal SecurableObjectType GetByNameApplication(string name, Application application)
        {
            Hashtable args = new Hashtable();
            args["name"] = name;
            args["applicationId"] = application.Id;

            return this.DataMapper.QueryForObject<SecurableObjectType>(
                    "securableObjectType-select-by-name-applicationId", args);
        }
    }
}
