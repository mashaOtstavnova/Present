using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Plugins.File;
using MvvmCross.Plugins.File.Droid;
using Presents.Core;
using Presents.Core.IServices;
using Presents.Droid.Services;

namespace Presents.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IEnumerable<Assembly> GetViewAssemblies()
        {
            var assemblies = base.GetViewAssemblies().ToList();
            assemblies.Add(typeof (Android.Support.Design.Widget.FloatingActionButton).Assembly);
            return assemblies;
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.RegisterSingleton<IGetProfileService>(() => new GetProfileService());
            Mvx.RegisterSingleton<IFileService>(() => new FileService());
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.Register<PluginLoader, Plugin>();
            registry
                .Register<MvvmCross.Plugins.DownloadCache.PluginLoader, MvvmCross.Plugins.DownloadCache.Droid.Plugin>();
            base.AddPluginsLoaders(registry);
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.DownloadCache.PluginLoader>();
            base.LoadPlugins(pluginManager);
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }
    }
}