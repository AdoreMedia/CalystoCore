﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalystoWebTests.Calysto.TypeLite.Validators {
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
    public class Validators {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Validators() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CalystoWebTests.Calysto.TypeLite.Validators.Validators", typeof(Validators).Assembly);
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
        ///   Looks up a localized string similar to {name} date may not be greater than {strMaxValue}.
        /// </summary>
        public static string CalystoDateTimeValidatorMaximumValue {
            get {
                return ResourceManager.GetString("CalystoDateTimeValidatorMaximumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} date may not be lower than {strMinValue}.
        /// </summary>
        public static string CalystoDateTimeValidatorMinimumValue {
            get {
                return ResourceManager.GetString("CalystoDateTimeValidatorMinimumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} date must be between {strMinValue} and {strMaxValue}.
        /// </summary>
        public static string CalystoDateTimeValidatorMustBeBetween {
            get {
                return ResourceManager.GetString("CalystoDateTimeValidatorMustBeBetween", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} is not in valid format for date.
        /// </summary>
        public static string CalystoDateTimeValidatorNotInValidFormat {
            get {
                return ResourceManager.GetString("CalystoDateTimeValidatorNotInValidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} is not in valid format for e-mail address.
        /// </summary>
        public static string CalystoEmailValidatorNotInValidFormat {
            get {
                return ResourceManager.GetString("CalystoEmailValidatorNotInValidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} number may not be greater than {strMaxValue}.
        /// </summary>
        public static string CalystoNumericValidatorMaximumValue {
            get {
                return ResourceManager.GetString("CalystoNumericValidatorMaximumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} number may not be lower than {strMinValue}.
        /// </summary>
        public static string CalystoNumericValidatorMinimumValue {
            get {
                return ResourceManager.GetString("CalystoNumericValidatorMinimumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} number must be between {strMinValue} and {strMaxValue}.
        /// </summary>
        public static string CalystoNumericValidatorMustBeBetween {
            get {
                return ResourceManager.GetString("CalystoNumericValidatorMustBeBetween", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} number is not in valid format.
        /// </summary>
        public static string CalystoNumericValidatorNotInValidFormat {
            get {
                return ResourceManager.GetString("CalystoNumericValidatorNotInValidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} is not in valid format.
        /// </summary>
        public static string CalystoRegexValidatorNotInValidFormat {
            get {
                return ResourceManager.GetString("CalystoRegexValidatorNotInValidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} length must be between {minLength} and {maxLength} chars.
        /// </summary>
        public static string CalystoStringValidatorLengthMustBeBetween {
            get {
                return ResourceManager.GetString("CalystoStringValidatorLengthMustBeBetween", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} maximum required length is {maxLength} chars.
        /// </summary>
        public static string CalystoStringValidatorMaximumRequiredLength {
            get {
                return ResourceManager.GetString("CalystoStringValidatorMaximumRequiredLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} minimum required length is {minLength} chars.
        /// </summary>
        public static string CalystoStringValidatorMinimumRequiredLength {
            get {
                return ResourceManager.GetString("CalystoStringValidatorMinimumRequiredLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {name} is required.
        /// </summary>
        public static string CalystoValidatorValueIsRequired {
            get {
                return ResourceManager.GetString("CalystoValidatorValueIsRequired", resourceCulture);
            }
        }
    }
}
