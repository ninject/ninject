﻿#region License
//
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2007-2010, Enkari, Ltd.
//
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
//
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Ninject.Infrastructure;
#endregion

namespace Ninject.Planning.Bindings
{
    /// <summary>
    /// Additional information available about a binding, which can be used in constraints
    /// to select bindings to use in activation.
    /// </summary>
    public class BindingMetadata : IBindingMetadata
    {
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the binding's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Determines whether a piece of metadata with the specified key has been defined.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <returns><c>True</c> if such a piece of metadata exists; otherwise, <c>false</c>.</returns>
        public bool Has(string key)
        {
            Contract.Requires(!string.IsNullOrEmpty(key));
            return _values.ContainsKey(key);
        }

        /// <summary>
        /// Gets the value of metadata defined with the specified key, cast to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of value to expect.</typeparam>
        /// <param name="key">The metadata key.</param>
        /// <returns>The metadata value.</returns>
        public T Get<T>(string key)
        {
            Contract.Requires(!string.IsNullOrEmpty(key));
            return Get(key, default(T));
        }

        /// <summary>
        /// Gets the value of metadata defined with the specified key.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="defaultValue">The value to return if the binding has no metadata set with the specified key.</param>
        /// <returns>The metadata value, or the default value if none was set.</returns>
        public T Get<T>(string key, T defaultValue)
        {
            Contract.Requires(!string.IsNullOrEmpty(key));
            return _values.ContainsKey(key) ? (T)_values[key] : defaultValue;
        }

        /// <summary>
        /// Sets the value of a piece of metadata.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        public void Set(string key, object value)
        {
            Contract.Requires(!string.IsNullOrEmpty(key));
            _values[key] = value;
        }
    }
}