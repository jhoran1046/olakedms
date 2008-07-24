using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using Microsoft.Search.Interop;

namespace Olake.WDS
{
    /// <summary>
    /// Summary description for CSearchDAL
    /// </summary>
    public class CSearchDAL
    {
        public CSearchDAL()
        {
        }

        // strPath: c:\folder\subfolder\
        public static void AddSearchFolder(string strPath)
        {
            if (strPath == null || strPath.Length == 0)
                return;

            CSearchManager manager = new CSearchManager();
            CSearchCatalogManager catalogManager = manager.GetCatalog("SystemIndex");
            CSearchCrawlScopeManager searchScopeManager = catalogManager.GetCrawlScopeManager();
            searchScopeManager.RevertToDefaultScopes();
            if (searchScopeManager.IncludedInCrawlScope("file:///" + strPath) == 0)
            {
                searchScopeManager.AddUserScopeRule("file:///" + strPath, 1, 1, 0);
                searchScopeManager.SaveAll();
            }
        }

        public static void RemoveSearchFolder(string strPath)
        {
            if (strPath == null || strPath.Length == 0)
                return;

            CSearchManager manager = new CSearchManager();
            CSearchCatalogManager catalogManager = manager.GetCatalog("SystemIndex");
            CSearchCrawlScopeManager searchScopeManager = catalogManager.GetCrawlScopeManager();
            searchScopeManager.RevertToDefaultScopes();
            searchScopeManager.RevertToDefaultScopes();
            searchScopeManager.RemoveScopeRule("file:///" + strPath);
        }

        //strPath: e.g. c:/disk
        public List<CSearchResultItem> SearchFolder(string strContent, string strPath)
        {
            List<CSearchResultItem> items = new List<CSearchResultItem>();
            if (strContent == null || strContent.Length == 0 || strPath == null || strPath.Length == 0)
                return items;

             // Thie uses SearchAPI interop assembly
            CSearchManager manager = new CSearchManager();

            // the SystemIndex catalog is the default catalog that windows uses
            CSearchCatalogManager catalogManager = manager.GetCatalog("SystemIndex");

            // get the ISearchQueryHelper which will help us to translate AQS --> SQL necessary to query the indexer
            CSearchQueryHelper queryHelper = catalogManager.GetQueryHelper();
            queryHelper.QueryContentLocale = 2052;
            queryHelper.QueryMaxResults = 100;
            queryHelper.QueryKeywordLocale = 2052;

            //queryHelper.
            // set the columns we want,只检索文件的名字和内容，不然属性太多了，会出现狗屁不通的结果。
            queryHelper.QuerySelectColumns = "System.ItemPathDisplay,System.Search.Rank,System.ItemNameDisplay";
            queryHelper.QueryWhereRestrictions = "AND scope='file:" + strPath + "'";
            queryHelper.QuerySorting = "System.ItemPathDisplay ASC ";
            // queryHelper.s
            queryHelper.QueryContentProperties = "System.Search.Contents,System.ItemNameDisplay";
            string sqlQuery = queryHelper.GenerateSQLFromUserQuery(strContent);
            
            // --- Perform the query ---
            // create an OleDbConnection object which connects to the indexer provider with the windows application
            System.Data.OleDb.OleDbConnection conn = new OleDbConnection(queryHelper.ConnectionString);

            try
            {
                // open it
                conn.Open();

                // now create an OleDB command object with the query we built above and the connection we just opened.
                OleDbCommand command = new OleDbCommand(sqlQuery, conn);

                // execute the command, which returns the results as an OleDbDataReader.
                OleDbDataReader WDSResults = command.ExecuteReader();

                while (WDSResults.Read())
                {
                    CSearchResultItem aResult = new CSearchResultItem();
                    aResult.FullPath = WDSResults.GetString(0);
                    aResult.Rank = WDSResults.GetInt32(1);
                    aResult.DispName = WDSResults.GetString(2);
                    items.Add(aResult);
                }

                WDSResults.Close();
            }
            catch (Exception e)
            {
            }
            finally
            {
                conn.Close();
            }

            return items;
        }
    }
}