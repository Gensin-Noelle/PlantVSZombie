## 项目依赖说明

在这个项目中，我移除了以下几个大文件和库，因为它们是特定于平台的，并且不需要在源代码管理中进行跟踪：

- `Library/PackageCache/com.unity.burst@1.8.11/.Runtime/burst-llvm-15.dll`
- `Library/PackageCache/com.unity.burst@1.8.11/.Runtime/hostmac/dsymutil`
- `Library/PackageCache/com.unity.burst@1.8.11/.Runtime/libburst-llvm-10.dylib`
- `Library/PackageCache/com.unity.burst@1.8.11/.Runtime/libburst-llvm-15.dylib`
- `Library/PackageCache/com.unity.burst@1.8.11/.Runtime/libburst-llvm-15.so`

请确保在运行项目之前，您已安装所需的依赖库。您可以通过 Unity Package Manager 安装 Burst 包，或根据项目要求从官方渠道下载这些文件。

## 运行项目

请确保在使用 Unity 编辑器打开项目时，安装了适当版本的 Burst 编译器和其他依赖项。
