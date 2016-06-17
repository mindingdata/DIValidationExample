using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;
using DIValidationExample.Infrastructure.Validation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DIValidationExample.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
				
				//Let's break this down. 
				//Get me all classes that inherit from CustomValidator. 
				//Then bind them to ICustomValidator. 
				//See below for other ways this can work. 

				container.RegisterTypes( AllClasses.FromLoadedAssemblies( ).Where( x => typeof( ICustomValidator ).IsAssignableFrom( x ) ), (type) => new[] {typeof(ICustomValidator)}, WithName.TypeName, WithLifetime.ContainerControlled);

			//Maps ALL interfaces on these types. But maybe they inherit from more than one interface. 
			//If we want to be explicit and only map what we know we want to map. Then this isn't a good option. 
			//container.RegisterTypes( AllClasses.FromLoadedAssemblies( ).Where( x => x.IsAssignableFrom( typeof( ICustomValidator ) ) ), WithMappings.FromAllInterfaces);

			//Similar to above but instead we just go. Hell. Get me all the classes in the world and bind them to all their interfaces. 
			//Similar a sledge hammer. May get you into strife as you have no control over bindings here. 
			//container.RegisterTypes( AllClasses.FromLoadedAssemblies( ) ), WithMappings.FromAllInterfaces);
		}
	}
}
