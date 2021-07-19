﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BowlingApp.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class BowlingResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BowlingResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BowlingApp.Resources.BowlingResources", typeof(BowlingResources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter the name of the file from which the data will be loaded:.
        /// </summary>
        internal static string EnterFileName {
            get {
                return ResourceManager.GetString("EnterFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File is empty or has incorrect format.
        /// </summary>
        internal static string FileFormatValidationError {
            get {
                return ResourceManager.GetString("FileFormatValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Loading of the file went wrong. Try again.
        /// </summary>
        internal static string FileLoadingError {
            get {
                return ResourceManager.GetString("FileLoadingError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The selected file does not exist or is empty. Try again:.
        /// </summary>
        internal static string FileSelectionError {
            get {
                return ResourceManager.GetString("FileSelectionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Given values are empty or they exceed the maximum limit of 21 elements.
        /// </summary>
        internal static string FileValuesCountError {
            get {
                return ResourceManager.GetString("FileValuesCountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Summary points in one frame cannot exceed 10 points.
        /// </summary>
        internal static string FrameConversionError {
            get {
                return ResourceManager.GetString("FrameConversionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No frames were found for calculations or their number is higher than 10.
        /// </summary>
        internal static string FramesCountError {
            get {
                return ResourceManager.GetString("FramesCountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One of the entered frames was not valid.
        /// </summary>
        internal static string FramesNotValidError {
            get {
                return ResourceManager.GetString("FramesNotValidError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player: {0}
        ///Game results could not be displayed because an unexpected error occured:
        ///{1}.
        /// </summary>
        internal static string NoResultsForPlayerError {
            get {
                return ResourceManager.GetString("NoResultsForPlayerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One of the given values is not in a range of 0 to 10.
        /// </summary>
        internal static string NumberNotInRangerError {
            get {
                return ResourceManager.GetString("NumberNotInRangerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player&apos;s name.
        /// </summary>
        internal static string PlayerNameHeader {
            get {
                return ResourceManager.GetString("PlayerNameHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Score.
        /// </summary>
        internal static string ScoreHeader {
            get {
                return ResourceManager.GetString("ScoreHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One of the given values is not a number.
        /// </summary>
        internal static string ValueIsNotNumberError {
            get {
                return ResourceManager.GetString("ValueIsNotNumberError", resourceCulture);
            }
        }
    }
}
