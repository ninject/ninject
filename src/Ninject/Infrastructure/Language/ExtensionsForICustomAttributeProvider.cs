//-------------------------------------------------------------------------------------------------
// <copyright file="ExtensionsForICustomAttributeProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2007-2009, Enkari, Ltd.
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Nate Kohari (nate@enkari.com)
//            Remo Gloor (remo.gloor@gmail.com)
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------------------------
namespace Ninject.Infrastructure.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides extension methods for <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    internal static class ExtensionsForICustomAttributeProvider
    {
        /// <summary>
        /// Determines if the <see cref="ICustomAttributeProvider"/> has the specified attribute.
        /// </summary>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/>.</param>
        /// <param name="type">The attribute type.</param>
        /// <returns><c>True</c> if the <see cref="ICustomAttributeProvider"/> has the attribute, otherwise <c>False</c>.</returns>
        public static bool HasAttribute(this ICustomAttributeProvider member, Type type)
        {
            var memberInfo = member as MemberInfo;
            if (memberInfo != null)
            {
                return memberInfo.HasAttribute(type);
            }

            return member.IsDefined(type, true);
        }

        /// <summary>
        /// Gets custom attributes which supports <see cref="MemberInfo"/> and <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="member">The <see cref="ICustomAttributeProvider"/>.</param>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute.</param>
        /// <returns>The attributes.</returns>
        public static IEnumerable<Attribute> GetCustomAttributesExtended(this ICustomAttributeProvider member, Type attributeType, bool inherit)
        {
            var memberInfo = member as MemberInfo;
            if (memberInfo != null)
            {
                return memberInfo.GetCustomAttributesExtended(attributeType, inherit);
            }

            return member.GetCustomAttributes(attributeType, inherit).Cast<Attribute>();
        }
    }
}