﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Politecnico.Patrones.ProyectoFinal.Lib.Recursos {
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
    public class Cadenas {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Cadenas() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Politecnico.Patrones.ProyectoFinal.Lib.Recursos.Cadenas", typeof(Cadenas).Assembly);
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
        ///   Looks up a localized string similar to Hace falta asociar el intérprete.
        /// </summary>
        public static string album_falta_interprete {
            get {
                return ResourceManager.GetString("album_falta_interprete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hace falta el nombre del álbum.
        /// </summary>
        public static string album_falta_nombre {
            get {
                return ResourceManager.GetString("album_falta_nombre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Album con id {0} no encontrado.
        /// </summary>
        public static string album_id_no_encontrado {
            get {
                return ResourceManager.GetString("album_id_no_encontrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hace falta el álbum de la canción o el intérprete.
        /// </summary>
        public static string cancion_falta_album_o_interprete {
            get {
                return ResourceManager.GetString("cancion_falta_album_o_interprete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hace falta el nombre de la canción.
        /// </summary>
        public static string cancion_falta_nombre {
            get {
                return ResourceManager.GetString("cancion_falta_nombre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Canción con id {0} no encontrada.
        /// </summary>
        public static string cancion_id_no_encontrado {
            get {
                return ResourceManager.GetString("cancion_id_no_encontrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hace falta el nombre del intérprete.
        /// </summary>
        public static string interprete_falta_nombre {
            get {
                return ResourceManager.GetString("interprete_falta_nombre", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Intérprete con id {0} no encontrado.
        /// </summary>
        public static string interprete_id_no_encontrado {
            get {
                return ResourceManager.GetString("interprete_id_no_encontrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///	interpretes: [
        ///		{	id: 1, nombre: &quot;Nicola di Bari&quot; },
        ///		{	id: 2, nombre: &quot;Metallica&quot; },
        ///		{	id: 3, nombre: &quot;Jhonny Cano&quot; },
        ///		{	id: 4, nombre: &quot;Debora Ramirez&quot; },
        ///	], 
        ///	albumes: [
        ///		{	id: 1, nombre: &quot;Con te Partiro&quot;, interpretes: [1] },
        ///		{	id: 2, nombre: &quot;Nothing else matters&quot;, interpretes: [2] },
        ///		{	id: 3, nombre: &quot;Por qué&quot;, interpretes: [3] },
        ///	], 
        ///	canciones: [
        ///		{	id: 1, nombre: &quot;Con te Partiro&quot;, album: 1 },
        ///		{	id: 2, nombre: &quot;Nothing else matters&quot;, album: 2 },
        ///		{	id: 3, nombre: &quot;P [rest of string was truncated]&quot;;.
        /// </summary>
        public static string seed_json {
            get {
                return ResourceManager.GetString("seed_json", resourceCulture);
            }
        }
    }
}
