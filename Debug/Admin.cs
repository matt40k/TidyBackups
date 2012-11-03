/*
 * This file is part of TidyBackups
 *
 * TidyBackups is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * TidyBackups is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with TidyBackups.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Security.Principal;
using System.Threading;

namespace TidyBackups.Debug
{
    /// <summary>
    /// Debug.Admin Class
    /// </summary>
    internal class Admin
    {
        /// <summary>
        /// Checks if the user is an admin
        /// </summary>
        protected internal static bool IsAdmin
        {
            get
            {
                AppDomain ad = Thread.GetDomain();

                ad.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                var user = (WindowsPrincipal) Thread.CurrentPrincipal;
                if (user.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    return true;
                }
                return false;
            }
        }
    }
}