﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuGot {
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
    internal class ResourceObjects {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceObjects() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuGot.ResourceObjects", typeof(ResourceObjects).Assembly);
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
        ///   Looks up a localized string similar to function uninstall_packages
        ///{
        ///	$list=@{
        ///{0}
        ///	}
        ///
        ///	foreach ($item in $list.GetEnumerator()) {
        ///		foreach ($idol in $item.Value)
        ///		{
        ///			try
        ///			{
        ///				uninstall-package -id $idol -projectname $item.Name
        ///			}
        ///			catch
        ///			{
        ///				Write-Host &quot;uninstall&quot;
        ///				Write-Host $idol -foregroundcolor red -backgroundcolor yellow
        ///				Write-Host $item.Name -foregroundcolor red -backgroundcolor white
        ///				#break
        ///				exit
        ///			}
        ///		}
        ///	}
        ///}
        ///
        ///function install_packages
        ///{
        ///	$list=@{
        ///{1}
        ///	}
        ///
        ///	$version = &quot;0.4.0.0&quot; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string String1 {
            get {
                return ResourceManager.GetString("String1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Package&gt;
        ///		&lt;Name&gt;{0}&lt;/Name&gt;
        ///		&lt;Path&gt;{1}&lt;/Path&gt;
        ///	&lt;/Package&gt;.
        /// </summary>
        internal static string String2 {
            get {
                return ResourceManager.GetString("String2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;RepositoryItem&gt;
        ///		&lt;Title&gt;{0}&lt;/Title&gt;
        ///		&lt;Order&gt;{1}&lt;/Order&gt;
        ///	&lt;/RepositoryItem&gt;.
        /// </summary>
        internal static string String3 {
            get {
                return ResourceManager.GetString("String3", resourceCulture);
            }
        }
    }
}