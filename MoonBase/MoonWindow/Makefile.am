
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/MoonWindow.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

MOONWINDOW_DLL_MDB_SOURCE=bin/Debug/MoonWindow.dll.mdb
MOONWINDOW_DLL_MDB=$(BUILD_DIR)/MoonWindow.dll.mdb
APPMANIFEST_XAML_SOURCE=AppManifest.xaml

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/MoonWindow.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

MOONWINDOW_DLL_MDB=
APPMANIFEST_XAML_SOURCE=AppManifest.xaml

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(MOONWINDOW_DLL_MDB) \
	$(APPMANIFEST_XAML)  

LINUX_PKGCONFIG = \
	$(MOONWINDOW_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES =  \
	AssemblyInfo.cs \
	MoonWindow.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	moonwindow.pc.in 

REFERENCES =  \
	../../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll \
	../../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll \
	../../../../../../../usr/lib/mono/moonlight/System.Windows.dll \
	-pkg:glib-sharp-2.0 \
	-pkg:gtk-sharp-2.0 \
	System

DLL_REFERENCES =  \
	../../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll \
	../../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll \
	../../../../../../../usr/lib/mono/moonlight/System.Windows.dll

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

APPMANIFEST_XAML = $(BUILD_DIR)/AppManifest.xaml
MOONWINDOW_PC = $(BUILD_DIR)/moonwindow.pc

$(eval $(call emit-deploy-target,APPMANIFEST_XAML))
$(eval $(call emit-deploy-wrapper,MOONWINDOW_PC,moonwindow.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
