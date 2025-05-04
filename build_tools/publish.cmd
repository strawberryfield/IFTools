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
set build=%bin%\build

set pkgname=Casasoft_IFTools
set nuget=%USERPROFILE%\.nuget\packages\
set winrar="%ProgramFiles%\WinRAR\winrar.exe"

set version=25.05.04
 
@del /S /Q %bin%

set prj=GBlorbLib
@dotnet build -c Release -o %build% -p:version="%version%" %repo%%prj%\%prj%.csproj
@move %build%\*.nupkg %bin%

set prj=GBlorbExtractor
@dotnet publish -c Release -o %build% -p:version="%version%" --no-self-contained %repo%%prj%\%prj%.csproj

set prj=GBlorbEd
@dotnet publish -c Release -o %build% -p:version="%version%" --no-self-contained %repo%%prj%\%prj%.csproj

@echo off
pushd .
cd %build%
copy %repo%LICENSE.txt .
copy %repo%README.md .
%winrar% a -r -m5 -s ..\%pkgname%_%version%.rar *.*
%winrar% k ..\%pkgname%_%version%.rar 
popd

rem only for debug 
:end