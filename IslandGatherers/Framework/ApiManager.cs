﻿using StardewModdingAPI;
using IslandGatherers.Framework.Interfaces;

namespace IslandGatherers.Framework
{
    internal static class ApiManager
    {
        private static IJsonAssetsApi jsonAssetsApi;
        private static IExpandedStorageApi expandedStorageApi;

        internal static bool HookIntoJsonAssets(IModHelper helper)
        {
            jsonAssetsApi = helper.ModRegistry.GetApi<IJsonAssetsApi>("spacechase0.JsonAssets");

            if (jsonAssetsApi is null)
            {
                IslandGatherers.monitor.Log("Failed to hook into spacechase0.JsonAssets.", LogLevel.Error);
                return false;
            }

            IslandGatherers.monitor.Log("Successfully hooked into spacechase0.JsonAssets.", LogLevel.Debug);
            return true;
        }

        public static bool HookIntoExpandedStorage(IModHelper helper)
        {
            // Attempt to hook into the IMobileApi interface
            expandedStorageApi = helper.ModRegistry.GetApi<IExpandedStorageApi>("furyx639.ExpandedStorage");

            if (expandedStorageApi is null)
            {
                IslandGatherers.monitor.Log("Failed to hook into furyx639.ExpandedStorage.", LogLevel.Error);
                return false;
            }

            IslandGatherers.monitor.Log("Successfully hooked into furyx639.ExpandedStorage.", LogLevel.Debug);
            return true;
        }

        internal static IJsonAssetsApi GetJsonAssetsApi()
        {
            return jsonAssetsApi;
        }

        internal static IExpandedStorageApi GetExpandedStorageApi()
        {
            return expandedStorageApi;
        }
    }
}
