

all: autogen
	make -C MoonBase

autogen: MoonBase/configure
	cd MoonBase; ./autogen.sh

install: all
	rm -f /usr/local/lib/moonbase/*
	make -C MoonBase install
	find /usr/local/lib/moonbase -type f -name '*.dll' -exec gacutil -i '{}' \;
