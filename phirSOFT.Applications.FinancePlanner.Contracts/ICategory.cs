// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="ICategory.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Applications.FinancePlanner.Contracts
// 
// Created by:    Philemon Eichin
// Created:       03.08.2017 10:37
// Last Modified: 03.08.2017 10:37
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace phirSOFT.Applications.FinancePlanner.Contracts
{
    [DataContract]
    public abstract class ICategory
    {
        [DataMember]
        [MinLength(1,ErrorMessage = "The title of a category cannot be empty.")]
        string Title { get; }

        [DataMember]
        ICategory Parent { get; }

        [DataMember]
        IList<ICategory> Children { get; set; }

        [DataMember]
        bool IsExpenseCategory { get; }
    }
}