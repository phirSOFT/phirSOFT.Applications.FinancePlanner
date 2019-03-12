// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="ICategoryService.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Applications.FinancePlanner.Contracts
// 
// Created by:    Philemon Eichin
// Created:       03.08.2017 11:34
// Last Modified: 03.08.2017 11:34
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
namespace phirSOFT.Applications.FinancePlanner.Contracts
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        void AddCategory(ICategory category, ICategory parent);

        [OperationContract]
        void DeleteCategory(ICategory category);

        [OperationContract]
        void UpdateCategory(ICategory category);

        [OperationContract]
        IList<ICategory> GetCategories();
    }
}