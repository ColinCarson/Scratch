﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.RedisService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RedisService.IRedisProvider")]
    public interface IRedisProvider {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRedisProvider/OpenSession", ReplyAction="http://tempuri.org/IRedisProvider/OpenSessionResponse")]
        void OpenSession();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRedisProvider/OpenSession", ReplyAction="http://tempuri.org/IRedisProvider/OpenSessionResponse")]
        System.Threading.Tasks.Task OpenSessionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRedisProviderChannel : Client.RedisService.IRedisProvider, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RedisProviderClient : System.ServiceModel.ClientBase<Client.RedisService.IRedisProvider>, Client.RedisService.IRedisProvider {
        
        public RedisProviderClient() {
        }
        
        public RedisProviderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RedisProviderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RedisProviderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RedisProviderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void OpenSession() {
            base.Channel.OpenSession();
        }
        
        public System.Threading.Tasks.Task OpenSessionAsync() {
            return base.Channel.OpenSessionAsync();
        }
    }
}