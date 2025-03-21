FROM mcr.microsoft.com/devcontainers/rust:latest

# Pass ID to the container
ARG UID=1000
ARG RUST_VERSION=1.85.1

RUN usermod -u $UID vscode

# Install rust version and components
RUN <<EOF
    rustup default $RUST_VERSION
    rustup target add x86_64-unknown-linux-musl
    rustup component add rustfmt
    rustup component add clippy
    rustup component add llvm-tools-preview

    curl \
    --proto '=https' \
    --tlsv1.2 -fsSL \
    https://github.com/taiki-e/cargo-llvm-cov/releases/latest/download/cargo-llvm-cov-$(rustc -vV | grep '^host:' | cut -d' ' -f2).tar.gz \
    | tar xzf - -C "/usr/local/cargo/bin"

    curl --proto '=https' --tlsv1.2 -sSf https://just.systems/install.sh | bash -s -- --to /usr/local/bin
EOF
