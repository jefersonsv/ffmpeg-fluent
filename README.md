# FFmpeg-Fluent

[![License](http://img.shields.io/:license-mit-blue.svg)](http://gep13.mit-license.org) [![NuGet version (FFmpeg-Fluent)](https://img.shields.io/nuget/v/ffmpeg-fluent.svg?style=flat-square)](https://www.nuget.org/packages/ffmpeg-fluent/)

FFmpeg is the leading multimedia framework, able to decode, encode, transcode, mux, demux, stream, filter and play pretty much anything that humans and machines have created. It supports the most obscure ancient formats up to the cutting edge. No matter if they were designed by some standards committee, the community or a corporation. It is also highly portable: FFmpeg compiles, runs, and passes our testing infrastructure FATE across Linux, Mac OS X, Microsoft Windows, the BSDs, Solaris, etc. under a wide variety of build environments, machine architectures, and configurations.

> **FFmpeg-Fluent is looking for maintainers**

# Table of content
<!-- TOC -->

- [FFmpeg-Fluent](#ffmpeg-fluent)
- [Table of content](#table-of-content)
- [Usage](#usage)
- [Utility](#utility)
    - [Install](#install)
    - [Uninstall](#uninstall)
    - [Usage](#usage-1)
    - [Run](#run)
- [Thanks](#thanks)

<!-- /TOC -->

# Usage

Sample usage

```c#

```

# Utility

This project contains a dotnet global utility _ffmpeg-batch_ to convert multiple files

## Install

```
dotnet tool install -g ffmpeg-batch
```

## Uninstall

```
dotnet tool uninstall -g ffmpeg-batch
```

## Usage

```
ffmpeg-batch <source-files> <destiny-files>
```


## Run

```
cd \some-directory
ffmpeg-batch *.wma *.mp3
```

# Thanks

- [FFmpeg](https://ffmpeg.org/) A complete, cross-platform solution to record, convert and stream audio and video
- [Colorful.Console](https://github.com/tomakita/Colorful.Console) C# library that wraps around the System.Console class, exposing enhanced styling functionality
- [CliWrap](https://github.com/Tyrrrz/CliWrap) Wrapper for command line interface executables
- [dotnetsay](https://github.com/dotnet/core/tree/master/samples/dotnetsay) Dotnetsay .NET Core Global Tools Sample
- [CommandLineParser](https://github.com/j-maly/CommandLineParser) Command line parser. Declarative arguments support
- [Microsoft.Extensions.FileSystemGlobbing]()
- [Contessa] Font by Christopher Joseph Pirillo