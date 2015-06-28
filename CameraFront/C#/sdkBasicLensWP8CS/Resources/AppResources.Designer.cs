/* 
    Copyright (c) 2012 - 2013 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://code.msdn.microsoft.com/wpapps
  
*/
namespace sdkBasicLensWP8CS.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("sdkBasicLensWP8CS.Resources.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete.
        /// </summary>
        public static string AppBarDeleteText {
            get {
                return ResourceManager.GetString("AppBarDeleteText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to flash.
        /// </summary>
        public static string AppBarFlashText {
            get {
                return ResourceManager.GetString("AppBarFlashText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to front.
        /// </summary>
        public static string AppBarFrontFacingCameraText {
            get {
                return ResourceManager.GetString("AppBarFrontFacingCameraText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Local Photo.
        /// </summary>
        public static string AppBarIsolatedStorageMenuItemSampleText {
            get {
                return ResourceManager.GetString("AppBarIsolatedStorageMenuItemSampleText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Media Library Photo.
        /// </summary>
        public static string AppBarMediaLibraryMenuItemSampleText {
            get {
                return ResourceManager.GetString("AppBarMediaLibraryMenuItemSampleText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Menu Item.
        /// </summary>
        public static string AppBarMenuItemText {
            get {
                return ResourceManager.GetString("AppBarMenuItemText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MY APPLICATION.
        /// </summary>
        public static string ApplicationTitle {
            get {
                return ResourceManager.GetString("ApplicationTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Camera Roll.
        /// </summary>
        public static string CameraRollAlbumName {
            get {
                return ResourceManager.GetString("CameraRollAlbumName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LeftToRight.
        /// </summary>
        public static string ResourceFlowDirection {
            get {
                return ResourceManager.GetString("ResourceFlowDirection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to en-US.
        /// </summary>
        public static string ResourceLanguage {
            get {
                return ResourceManager.GetString("ResourceLanguage", resourceCulture);
            }
        }
    }
}
