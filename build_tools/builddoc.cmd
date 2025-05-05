@echo off
rem copyright (c) 2025 Roberto Ceccarelli - Casasoft
rem http://strawberryfield.altervista.org 
rem 
rem This file is part of Casasoft IF Tools
rem https://github.com/strawberryfield/Contemporary_CDV
rem 
rem Casasoft IF Tools is free software: 
rem you can redistribute it and/or modify it
rem under the terms of the GNU Affero General Public License as published by
rem the Free Software Foundation, either version 3 of the License, or
rem (at your option) any later version.
rem 
rem Casasoft IF Tools is distributed in the hope that it will be useful,
rem but WITHOUT ANY WARRANTY; without even the implied warranty of
rem MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
rem See the GNU General Public License for more details.
rem 
rem You should have received a copy of the GNU AGPL v.3
rem along with Casasoft IF Tools.  
rem If not, see <http://www.gnu.org/licenses/>.
@echo on

set name=IFTools
set repo=C:\projects\%name%\
set docs=%repo%docs\
set bin=%repo%bin\
set build=%bin%build

set pkgname=Casasoft_IFTools

@echo off
set dotnet=%USERPROFILE%\.dotnet\tools\

pushd .
cd %build%
@echo on
"%dotnet%xmldoc2md" %build%\Casasoft.IF.GblorbLib.dll -o "%repo%docs" --github-pages --index-page-name GblorbLib-index >nul

set name=GBlorbExtractor
@echo off
call :prg_help
@echo on
set name=GBlorbEd
@echo off
call :prg_help

popd
goto :end

:prg_help
set file="%repo%docs\%name%.md"
echo # Command line usage for %name% >%file%
echo ``` >>%file%
%name% -h >>%file%
echo ``` >>%file%
exit /b

:end