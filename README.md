# Alti-2 Reader

## Altimaster N-series devices data reader

Copyright (C) 2011 Alexey Lobanov <aklobanov@gmail.com>

This program is free software: you can redistribute it and/or modify it under
the terms of the GNU General Public License as published by the Free Software
Foundation, either version 3 of the License, or (at your option) any later
version.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRENTY; without even the implied warrenty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You should have received a copy of the GNU General Public License along with
this program.  If not, see <http://www.gnu.org/licenses/>.

### 1. Requirements

Microsoft .NET 4.0 Framework Client package must be installed to use this
program. Altimaster USB drivers should be installed to work with N3 or N3
Audio devices. Infrared Adapter should be used to work with N2 device. I
recommend use Tekram IRMate-410U under Windows XP and Tekram IRMate-210
under Windows 7 x64. N2 device should use firmware 2.6.2 or grater to
communicate with the program.

### 2. General

This program can't be used to change any settings of the N-series devices.
To change settings use Altimaster N-series Utility (NMU). With this program
you can read, display and print most kind of Altimaster N-series device
information such as logbook summary and jumps detail, jumps profiles for 256
jumps (for new versions of N2 firmware and for N3/N3A). Also you can build
statistics graphs with stored jumps information.

### 3. New Features

In this program release reading and showing jump's profiles and building graphs
are implemented. Internal format of the binary archive is changed from previous
versions so you can't read archives saved with previous versions of the program.

### 4. Issues

Please report issues in via the Github
[issue tracker](https://github.com/evilwombat/alti2reader/issues).
