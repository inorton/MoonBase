
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/Mono.MoonDesk.ViewLoader.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

MONO_MOONDESK_VIEWLOADER_DLL_MDB_SOURCE=bin/Debug/Mono.MoonDesk.ViewLoader.dll.mdb
MONO_MOONDESK_VIEWLOADER_DLL_MDB=$(BUILD_DIR)/Mono.MoonDesk.ViewLoader.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/Mono.MoonDesk.ViewLoader.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

MONO_MOONDESK_VIEWLOADER_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(MONO_MOONDESK_VIEWLOADER_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(MONO_MOONDESK_VIEWLOADER_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES =  \
	AssemblyInfo.cs \
	ViewLoader.cs \
	ViewModelBase.cs \
	ViewResolver.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	mono.moondesk.viewloader.pc.in 

REFERENCES =  \
	../Mono.MoonDesk.Commands/bin/Debug/Mono.MoonDesk.Commands.dll \
	-pkg:moonlight-desktop-4.0 \
	-pkg:moonlight-gtk-4.0 \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

MONO_MOONDESK_VIEWLOADER_PC = $(BUILD_DIR)/mono.moondesk.viewloader.pc

$(eval $(call emit-deploy-wrapper,MONO_MOONDESK_VIEWLOADER_PC,mono.moondesk.viewloader.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
