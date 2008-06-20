using System;
namespace Framework.DB
{
    public interface IPersistableData
     
    {
        string ConnString { set; }
        string Name { set;get;}

        object Load(params object[] keyValues);
      
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete ( );
        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        void Delete ( string filter );
        /// <summary>
        /// Deletes the children.
        /// </summary>
        /// <param name="foreignKeyValues">The foreign key values.</param>
        /// <returns></returns>
        int DeleteChildren ( params object [ ] foreignKeyValues );
        /// <summary>
        /// Gets the data reader.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        System.Data.IDataReader GetDataReader ( string filter );
        /// <summary>
        /// Gets the data reader.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="subsetFilter">The subset filter.</param>
        /// <returns></returns>
        System.Data.IDataReader GetDataReader ( string filter , string subsetFilter );
        System.Data.IDataReader GetDataReader(Grove.ORM.ObjectQuery query);
        /// <summary>
        /// Gets the obejct source.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="subsetFilter">The subset filter.</param>
        /// <returns></returns>
        Grove.EntityData GetObjectSource ( string filter , string subsetFilter );
        /// <summary>
        /// Gets the obejct source.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        Grove.EntityData GetObjectSource ( string filter );
        Grove.EntityData GetObjectSource(Grove.ORM.ObjectQuery query);
        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        System.Collections.ArrayList GetObjectSet ( string filter );
        
        System.Collections.ArrayList GetObjectSet(Grove.ORM.ObjectQuery query);
        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="subsetFilter">The subset filter.</param>
        /// <returns></returns>
        System.Collections.ArrayList GetObjectSet ( string filter , string subsetFilter );
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        int Insert ( );

        /// <summary>
        /// Updates the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="properties">The properties.</param>
        void Update ( string filter , params string [ ] properties );
        /// <summary>
        /// Updates the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        void Update ( string filter );
        /// <summary>
        /// Updates this instance.
        /// </summary>
        void Update ( );
    }
}
