
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug -define:DEBUG "-define:DEBUG MOONLIGHT_DESKTOP"
ASSEMBLY = bin/Mono.MoonDesk.MoonBase.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/

MONO_MOONDESK_MOONBASE_DLL_MDB_SOURCE=bin/Mono.MoonDesk.MoonBase.dll.mdb
MONO_MOONDESK_MOONBASE_DLL_MDB=$(BUILD_DIR)/Mono.MoonDesk.MoonBase.dll.mdb

endif

ifeq ($(CONFIG),MONODEBUG)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug -define:DEBUG -sdk:2  "-define:DEBUG MOONLIGHT_DESKTOP"
ASSEMBLY = bin/Mono.MoonDesk.MoonBase.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/

MONO_MOONDESK_MOONBASE_DLL_MDB_SOURCE=bin/Mono.MoonDesk.MoonBase.dll.mdb
MONO_MOONDESK_MOONBASE_DLL_MDB=$(BUILD_DIR)/Mono.MoonDesk.MoonBase.dll.mdb

endif

ifeq ($(CONFIG),MONORELEASE)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- "-define:MOONLIGHT_DESKTOP"
ASSEMBLY = bin/Mono.MoonDesk.MoonBase.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/

MONO_MOONDESK_MOONBASE_DLL_MDB=

endif

ifeq ($(CONFIG),RELEASE)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Mono.MoonDesk.MoonBase.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/

MONO_MOONDESK_MOONBASE_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(MONO_MOONDESK_MOONBASE_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(MOONBASE_MOONLIGHT_PC)  


RESGEN=resgen2

MOONBASE_MOONLIGHT_PC = $(BUILD_DIR)/moonbase_moonlight.pc

FILES = \
	AssemblyInfo.cs \
	MoonWindow.cs \
	ISilverlightContainer.cs \
	MoonArea.cs \
	MoonBase.cs \
	MoonBaseException.cs \
	MoonBaseDeployment.cs \
	Command.cs \
	MVVM/DispatchPropertyBase.cs \
	MVVM/NotifyPropertyBase.cs \
	MVVM/ViewLoader.cs \
	MVVM/ViewModelBase.cs \
	MVVM/VVM.cs \
	Window/AWindow-windows.cs \
	Window/AWindow-moonlight.cs \
	Window/IWindow.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	moonbase_moonlight.pc.in 

REFERENCES =  \
	System \
	-pkg:gtk-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:moonlight-gtk-4.0 \
	-pkg:moonlight-desktop-4.0

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-wrapper,MOONBASE_MOONLIGHT_PC,moonbase_moonlight.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MONO_MOONDESK_MOONBASE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/pkgconfig'
	$(call cp,$(MOONBASE_MOONLIGHT_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MONO_MOONDESK_MOONBASE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MOONBASE_MOONLIGHT_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
