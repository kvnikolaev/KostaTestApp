﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceManager.DALServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Department_dto", Namespace="http://schemas.datacontract.org/2004/07/DALService.DTO")]
    [System.SerializableAttribute()]
    public partial class Department_dto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceManager.DALServiceReference.Department_dto[] ChildDepartmentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceManager.DALServiceReference.Employee_dto[] EmployeeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.Guid> ParentDepartmentIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceManager.DALServiceReference.Department_dto[] ChildDepartments {
            get {
                return this.ChildDepartmentsField;
            }
            set {
                if ((object.ReferenceEquals(this.ChildDepartmentsField, value) != true)) {
                    this.ChildDepartmentsField = value;
                    this.RaisePropertyChanged("ChildDepartments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceManager.DALServiceReference.Employee_dto[] Employee {
            get {
                return this.EmployeeField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeField, value) != true)) {
                    this.EmployeeField = value;
                    this.RaisePropertyChanged("Employee");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.Guid> ParentDepartmentID {
            get {
                return this.ParentDepartmentIDField;
            }
            set {
                if ((this.ParentDepartmentIDField.Equals(value) != true)) {
                    this.ParentDepartmentIDField = value;
                    this.RaisePropertyChanged("ParentDepartmentID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee_dto", Namespace="http://schemas.datacontract.org/2004/07/DALService.DTO")]
    [System.SerializableAttribute()]
    public partial class Employee_dto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateOfBirthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceManager.DALServiceReference.Department_dto DepartmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid DepartmentIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocSeriesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PatronymicField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PositionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOfBirth {
            get {
                return this.DateOfBirthField;
            }
            set {
                if ((this.DateOfBirthField.Equals(value) != true)) {
                    this.DateOfBirthField = value;
                    this.RaisePropertyChanged("DateOfBirth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceManager.DALServiceReference.Department_dto Department {
            get {
                return this.DepartmentField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentField, value) != true)) {
                    this.DepartmentField = value;
                    this.RaisePropertyChanged("Department");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid DepartmentID {
            get {
                return this.DepartmentIDField;
            }
            set {
                if ((this.DepartmentIDField.Equals(value) != true)) {
                    this.DepartmentIDField = value;
                    this.RaisePropertyChanged("DepartmentID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocNumber {
            get {
                return this.DocNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.DocNumberField, value) != true)) {
                    this.DocNumberField = value;
                    this.RaisePropertyChanged("DocNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocSeries {
            get {
                return this.DocSeriesField;
            }
            set {
                if ((object.ReferenceEquals(this.DocSeriesField, value) != true)) {
                    this.DocSeriesField = value;
                    this.RaisePropertyChanged("DocSeries");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Patronymic {
            get {
                return this.PatronymicField;
            }
            set {
                if ((object.ReferenceEquals(this.PatronymicField, value) != true)) {
                    this.PatronymicField = value;
                    this.RaisePropertyChanged("Patronymic");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Position {
            get {
                return this.PositionField;
            }
            set {
                if ((object.ReferenceEquals(this.PositionField, value) != true)) {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SurName {
            get {
                return this.SurNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurNameField, value) != true)) {
                    this.SurNameField = value;
                    this.RaisePropertyChanged("SurName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DALServiceReference.IDALService")]
    public interface IDALService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/GetDepartmentStructureWithEmployees", ReplyAction="http://tempuri.org/IDALService/GetDepartmentStructureWithEmployeesResponse")]
        ServiceManager.DALServiceReference.Department_dto[] GetDepartmentStructureWithEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/GetDepartmentStructureWithEmployees", ReplyAction="http://tempuri.org/IDALService/GetDepartmentStructureWithEmployeesResponse")]
        System.Threading.Tasks.Task<ServiceManager.DALServiceReference.Department_dto[]> GetDepartmentStructureWithEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/AddEmployee", ReplyAction="http://tempuri.org/IDALService/AddEmployeeResponse")]
        int AddEmployee(ServiceManager.DALServiceReference.Employee_dto employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/AddEmployee", ReplyAction="http://tempuri.org/IDALService/AddEmployeeResponse")]
        System.Threading.Tasks.Task<int> AddEmployeeAsync(ServiceManager.DALServiceReference.Employee_dto employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/AddDepartment", ReplyAction="http://tempuri.org/IDALService/AddDepartmentResponse")]
        System.Guid AddDepartment(ServiceManager.DALServiceReference.Department_dto department);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/AddDepartment", ReplyAction="http://tempuri.org/IDALService/AddDepartmentResponse")]
        System.Threading.Tasks.Task<System.Guid> AddDepartmentAsync(ServiceManager.DALServiceReference.Department_dto department);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDALServiceChannel : ServiceManager.DALServiceReference.IDALService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DALServiceClient : System.ServiceModel.ClientBase<ServiceManager.DALServiceReference.IDALService>, ServiceManager.DALServiceReference.IDALService {
        
        public DALServiceClient() {
        }
        
        public DALServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DALServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DALServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DALServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServiceManager.DALServiceReference.Department_dto[] GetDepartmentStructureWithEmployees() {
            return base.Channel.GetDepartmentStructureWithEmployees();
        }
        
        public System.Threading.Tasks.Task<ServiceManager.DALServiceReference.Department_dto[]> GetDepartmentStructureWithEmployeesAsync() {
            return base.Channel.GetDepartmentStructureWithEmployeesAsync();
        }
        
        public int AddEmployee(ServiceManager.DALServiceReference.Employee_dto employee) {
            return base.Channel.AddEmployee(employee);
        }
        
        public System.Threading.Tasks.Task<int> AddEmployeeAsync(ServiceManager.DALServiceReference.Employee_dto employee) {
            return base.Channel.AddEmployeeAsync(employee);
        }
        
        public System.Guid AddDepartment(ServiceManager.DALServiceReference.Department_dto department) {
            return base.Channel.AddDepartment(department);
        }
        
        public System.Threading.Tasks.Task<System.Guid> AddDepartmentAsync(ServiceManager.DALServiceReference.Department_dto department) {
            return base.Channel.AddDepartmentAsync(department);
        }
    }
}
