﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Politecnico.Patrones.ObjetoActivo01.Consola.Recursos {
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
    internal class Archivos {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Archivos() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Politecnico.Patrones.ObjetoActivo01.Consola.Recursos.Archivos", typeof(Archivos).Assembly);
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
        ///   Looks up a localized string similar to                          Objeto Activo
        ///
        ///                   Ejercicio presentado por
        ///                    Ing: Jhonny Dickson Cano
        ///
        ///Para materia: Conceptos Avanzados en Diseño de Software
        ///Profesor: Danilo Castro Tellez
        ///
        ///
        ///Ejercicios disponibles también en
        ///https://github.com/jhonnycano/politecnico.s1.patrones
        ///
        ///El programa pide un número de trabajos a disparar de manera concurrente.
        ///Cada trabajo tendrá una cantidad aleatoria de iteraciones 
        ///y una duración (milisegundos) aleatoria.
        ///
        ///El log se alma [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Inicio {
            get {
                return ResourceManager.GetString("Inicio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cuantas iteraciones por trabajo (1-100) (enter=10)?.
        /// </summary>
        internal static string str_cuantas_iteraciones {
            get {
                return ResourceManager.GetString("str_cuantas_iteraciones", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duración de cada iteración (milisegundos)(1-5000) (enter=500)?.
        /// </summary>
        internal static string str_cuanto_peso {
            get {
                return ResourceManager.GetString("str_cuanto_peso", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cuantos trabajos a generar (0-100) (enter=10) (0=salir)?.
        /// </summary>
        internal static string str_cuantos_trabajos {
            get {
                return ResourceManager.GetString("str_cuantos_trabajos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Trabajos terminados.
        /// </summary>
        internal static string str_trabajos_terminados {
            get {
                return ResourceManager.GetString("str_trabajos_terminados", resourceCulture);
            }
        }
    }
}
