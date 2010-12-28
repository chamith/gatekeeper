using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using IBatisNet.DataMapper;
using System.Configuration;
using IBatisNet.DataMapper.Configuration;
using System.IO;
using log4net;

namespace Gatekeeper.Core
{
    public class BaseDao<EntityType> : MarshalByRefObject where EntityType : BaseEntity
    {
        ISqlMapper _dataMapper;
        string _entityLowercase;
		private static ILog log = log4net.LogManager.GetLogger(typeof(BaseDao<EntityType>)); 
        public BaseDao(ISqlMapper dataMapper)
        {
            this._dataMapper = dataMapper;

            ConnectionStringSettings connection = ConfigurationManager.ConnectionStrings[this._dataMapper.DataSource.Name];
            this._dataMapper.DataSource.ConnectionString = connection.ConnectionString;

            string firstChar = typeof(EntityType).Name[0].ToString().ToLower();
            string rest = typeof(EntityType).Name.Substring(1);
            this._entityLowercase = firstChar + rest;
        }


        protected ISqlMapper DataMapper
        {
            get
            {
                return this._dataMapper;
            }
        }

        public void Add(EntityType entity)
        {
           	EntityType tmp = this.DataMapper.QueryForObject<EntityType>(this._entityLowercase +"-insert", entity);
			Console.WriteLine(log.IsDebugEnabled);
			log.DebugFormat("Entity {0} inserted with Id {1}", this._entityLowercase, tmp.Id);
			Console.WriteLine("Entity {0} inserted with Id {1}", this._entityLowercase, tmp.Id);
			entity.Id = tmp.Id;

        }

        public void Delete(EntityType entity)
        {
            this.DataMapper.Delete(this._entityLowercase + "-delete", entity.Id);
        }

        public void Update(EntityType entity)
        {
            this.DataMapper.Update(this._entityLowercase + "-update", entity);
        }

        public EntityType Get(long id)
        {
            return this.DataMapper.QueryForObject<EntityType>(this._entityLowercase + "-select", id);
        }

        protected DateTime GetToDate(DateTime date)
        {
            return date.Date.Add(new TimeSpan(23, 59, 59));
        }

        protected DateTime GetFromDate(DateTime date)
        {
            return date.Date;
        }
    }
}
