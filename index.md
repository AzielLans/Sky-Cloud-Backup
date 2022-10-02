---
layout: home
home: true
---

<img src="https://user-images.githubusercontent.com/100028421/160099110-7571a93c-a1a1-4f45-b969-d7f4dccc3b4c.png"/>

You can preview the theme to [see what it looks like](https://involts.github.io/jekyll-theme-fica/) or
[download it today!](https://github.com/Involts/jekyll-theme-fica/zipball/master)

[![Gem Version](https://badge.fury.io/rb/jekyll-theme-fica.svg)](https://badge.fury.io/rb/jekyll-theme-fica)

# Installation

### Step 1:

Add `gem 'jekyll-theme-fica', '~> 0.2.0'` to your `Gemfile`

### Step 2:

Add `theme: jekyll-theme-fica`, if you run it locally and

`remote_theme: Involts/jekyll-theme-fica`, if you using GitHub-Pages to your `_config.yml`.

### Step 3:

Run `$ bin/run insdep`, if you download it on Github and

`$ bundle install`, if you download it on RubyGems.org

### Step 4:

Run `$ bin/run server`, if you download it on Github and

`$ bundle exec jekyll serve` if you download it on RubyGems.org

## Reminders:

> Before publishing the site to github-pages, replace the varable of baseurl `baseurl: /jekyll-fica-theme` in the `_config.yml` in `_config.yml` .
> if you have brought a doman remove the varable `baseurl: /jekyll-fica-theme` in the `_config.yml`
{: .prompt-info }

# Customiztion

## Customizing `_config.yml`

Fica Theme will respect the following variables, in your `_config.yml` file:

```yml
title: [The title of your site]
description: [A short description of your site's purpose]

socials:
  # Change Involts to your full name.
  name: [The auther of the site]
  # it also be the copyright owner's link
  auther-link: [Link of the auther]
```

Change the links of your site header:

```yml
header:
  external_link_1: true # if false, it adds the baseurl of the site
  header_name_1: Download
  header_link_1: https://github.com/Involts/jekyll-theme-fica/zipball/master

  external_link_2: false # if false, it adds the baseurl of the site
  header_name_2: Post
  header_link_2: /Post/

  external_link_3: false # if false, it adds the baseurl of the site
  header_name_3: About
  header_link_3: /About/
```

## `bin/run` testing command suite:

### Usage:

`bin/run` **subcommand**

| Subcommand          | Description                                        |
| ------------------- | -------------------------------------------------- |
| `upgrade` , `u`     | Upgrades `jekell-theme-fica` to the latest version |
| `help` , `h`        | Print help.                                        |
| `version` , `v`     | Print version.                                     |
| `server` , `s`      | Runs the server locally                            |
| `insdep` , `idp`    | Installs all the dependencies                      |
| `chktheme` , `ckte` | Checks the theme for errors                        |

## Customizing the Styles, Vriables and Color Scheme:

if you like to override the default styles of the theme, go to `_sass/Custom/Styles.scss`.

if you like to override the default Variables of the theme, go to `_sass/Custom/Variable.scss`.

if you like to change the colors of the Dark Theme in the site, go to `_sass/themes/dark theme/Dark_Theme.scss`.

if you like to change the colors of the Light Theme in the site, go to `_sass/themes/dark theme/Light_Theme.scss`.

Want to change [the themes?](#how-to-change-dark-mode-to-light-mode)

## How to replace the logo on the header ?

Replace logo.png at the top of your site.
Make sure that the logo is 36x36 pixels to avoid overlapping the title.

## how to replace the pictue at the homepage ?

Replace `assets/img/homepage-pic.png`

# Customizing Google Analytics code

Google has released several iterations to their Google Analytics code over the years since this theme was first created. If you would like to take advantage of the latest code, paste it into `_includes/Google-Analytics.html` in your Jekyll site.

## how to change dark mode to light mode

Replace:

```diff
- "themes/dark theme/theme-dark",
+ "themes/light theme/theme-light",
```

in `_sass/jekyll-theme-fica.scss`.

## Contributing

Interested in contributing to Fica Theme? We'd love your help. Fica Theme is an open source project, built one contribution at a time by users like you. See [the contributing file](docs/contributing.md) for instructions on how to contribute.

The theme is available as open source under the terms of the [MIT License](https://opensource.org/licenses/MIT).
