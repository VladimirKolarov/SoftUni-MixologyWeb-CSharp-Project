﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace MixologyWeb.ModelBinders
{
    public class DoubleModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !String.IsNullOrEmpty(valueResult.FirstValue))
            {
                double actualValue = 0;
                bool success = false;

                try
                {
                    string value = valueResult.FirstValue;
                    value = value.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    value = value.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    actualValue = Convert.ToDouble(value, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (FormatException exception)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, exception, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}