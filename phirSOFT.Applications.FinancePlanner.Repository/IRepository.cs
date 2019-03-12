// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="IRepository.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Applications.FinancePlanner.Contracts
// 
// Created by:    Philemon Eichin
// Created:       03.08.2017 10:43
// Last Modified: 03.08.2017 10:43
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace phirSOFT.Applications.FinancePlanner.Contracts
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Adds an entry into the repository
        /// </summary>
        /// <typeparam name="T">The type of the entry to be added.</typeparam>
        /// <param name="entity">The entry to be added.</param>
        /// <returns>Returns the index of the addet obect</returns>
        int Add<T>(T entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update<T>(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete<T>(T entity);

        /// <summary>
        /// Enumerates all entries of a given type in this repository.
        /// </summary>
        /// <typeparam name="T">The type of the enrty.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> that enumerates all entries of the given type.</returns>
        IEnumerable<T> GetEntries<T>();

        
    }
}