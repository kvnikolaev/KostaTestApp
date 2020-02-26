using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace ServiceManager.ClientSideClasses
{
    public abstract class EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate()
        {
            var validationResults = this.PropertyValidator();

            if (validationResults.Count > 0)
            {
                var validationExceptions = validationResults.Select(v => new ValidationException(v.ErrorMessage));
                AggregateException aggregate = new AggregateException(validationExceptions);
                throw aggregate;
            }

            return true;
        }

        private ICollection<ValidationResult> PropertyValidator()
        {
            var validationResults = new Collection<ValidationResult>();
            var propertyCollection = TypeDescriptor.GetProperties(this);

            foreach (PropertyDescriptor property in propertyCollection)
            {
                Validator.TryValidateProperty(
                    property.GetValue(this),
                    new ValidationContext(this, null, null) { MemberName = property.Name},
                    validationResults);
            }
            return validationResults;
        }
    }
}
